using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Clidades;
using Tecsmart.Suporte.Clientes.Dto;
using Tecsmart.Suporte.Clientes.Omie;
using Tecsmart.Suporte.Clientes.Omie.Contratos;
using Tecsmart.Suporte.Contratos;
using Tecsmart.Suporte.Contratos.Dto;
using Tecsmart.Suporte.Tags;

namespace Tecsmart.Suporte.Clientes
{
    [AbpAuthorize(PermissionNames.Pages_Clientes)]
    public class ClienteAppService : SuporteAppServiceBase, IClienteAppService
    {
        private readonly IRepository<Cliente, int> _clienteRepository;
        private readonly IRepository<ClienteView, int> _clienteViewRepository;
        private readonly IRepository<Contrato, long> _contratoRepository;
        private readonly IRepository<Cidade, int> _cidadeRepository;
        private readonly IRepository<Tag, int> _tagRepository;
        private readonly IRepository<TagCliente, int> _tagClienteRepository;
        private readonly IMapper _mapper;

        public ClienteAppService(IRepository<Cliente, int> clienteRepository,
                                 IRepository<ClienteView, int> clienteViewRepository,
                                 IRepository<Contrato, long> contratoRepository,
                                 IRepository<Cidade, int> cidadeRepository,
                                 IRepository<Tag, int> tagRepository,
                                 IRepository<TagCliente, int> tagClienteRepository,
                                 IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _clienteViewRepository = clienteViewRepository;
            _contratoRepository = contratoRepository;
            _cidadeRepository = cidadeRepository;
            _tagRepository = tagRepository;
            _tagClienteRepository = tagClienteRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        public async Task<GetClienteForEditOutput> GetClienteForEdit(EntityDto<int> input)
        {
            var cliente = await _clienteRepository.GetAllIncluding(c => c.CidadeFk).Where(x => x.Id == input.Id).FirstOrDefaultAsync();
            var output = new GetClienteForEditOutput { Cliente = ObjectMapper.Map<CreateOrEditClienteDto>(cliente) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditClienteDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        protected virtual async Task Create(CreateOrEditClienteDto input)
        {
            var cliente = ObjectMapper.Map<Cliente>(input);
            await _clienteRepository.InsertAsync(cliente);
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        protected virtual async Task Update(CreateOrEditClienteDto input)
        {
            var cliente = await _clienteRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, cliente);
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        public async Task Delete(EntityDto<int> input)
        {
            await _clienteRepository.DeleteAsync(input.Id);
        }


        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredClientes = _clienteViewRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<ClienteView, ClienteViewDto>(_mapper, filteredClientes, loadOptions);
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes)]
        public async Task<LoadResult> GetContratosCliente(DataSourceLoadOptions loadOptions)
        {
            var filteredContratos = _contratoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Contrato, ContratoDto>(_mapper, filteredContratos, loadOptions);
        }

        [AbpAuthorize(PermissionNames.Pages_Clientes_Omie)]
        public async Task IntegracaoOmie(EntityDto<bool> input)
        {
            int paginas = await RetornaTotalPgClientes();
            int inicio = paginas;
            if (input.Id)
            {
                await IntegracaoOmieContratos();
                inicio = 1;
            }
            for (int i = inicio; i <= paginas; i++)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://app.omie.com.br/api/v1/geral/clientes/"))
                    {
                        request.Content = new StringContent("{\"call\":\"ListarClientes\",\"app_key\":\"38333295000\",\"app_secret\":\"4cea520a0e2a2ecdc267b75d3424a0ed\",\"param\":[{\"pagina\":"+i+",\"registros_por_pagina\":50,\"apenas_importado_api\":\"N\"}]}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var clientes = JsonConvert.DeserializeObject<Resposta>(jsonResult);
                        foreach (var cliente in clientes.clientes_cadastro)
                        {
                            try
                            {
                                int enderecoNumero = 0;
                                int.TryParse(cliente.endereco_numero, out enderecoNumero);
                                Cliente clienteBanco = new()
                                {
                                    CpfCnpj = cliente.cnpj_cpf,
                                    NomeFantasia = cliente.nome_fantasia,
                                    RazaoSocial = cliente.razao_social,
                                    NumeroERP = cliente.codigo_cliente_omie,
                                    CidadeId = await RetornaCidade(cliente.cidade_ibge),
                                    Email = cliente.email,
                                    EnderecoRua = cliente.endereco,
                                    EnderecoNumero = enderecoNumero,
                                    EnderecoBairro = cliente.bairro,
                                    EnderecoComplemento = cliente.complemento,
                                    EnderecoCep = cliente.cep,
                                    Telefone = cliente.telefone1,
                                    Contato = cliente.contato
                                };
                                var clienteCadastrado = await _clienteRepository.FirstOrDefaultAsync(p => p.NumeroERP == cliente.codigo_cliente_omie);
                                if (clienteCadastrado == null)
                                {
                                    clienteBanco.ClienteObs = "  -  -    " + Environment.NewLine + "Sistema Operacional: " + Environment.NewLine + "Versão do sistema: " + Environment.NewLine + "Senha Postgres: Admin" + Environment.NewLine + "IP Servidor: " + Environment.NewLine + "Acesso teamviewer Servidor: " + Environment.NewLine + "Email Maps Bing:  exemplo@outlook.com  / Senha: mobile123" + Environment.NewLine + "Caminho do backup: ";
                                    var clienteId = await _clienteRepository.InsertAndGetIdAsync(clienteBanco);
                                    await CadastraAtualizaTags(clienteId, cliente.tags);
                                }
                                else
                                {
                                    clienteCadastrado.CpfCnpj = clienteBanco.CpfCnpj;
                                    clienteCadastrado.NomeFantasia = clienteBanco.NomeFantasia;
                                    clienteCadastrado.RazaoSocial = clienteBanco.RazaoSocial;
                                    clienteCadastrado.NumeroERP = clienteBanco.NumeroERP;
                                    clienteCadastrado.CidadeId = clienteBanco.CidadeId;
                                    clienteCadastrado.Email = clienteBanco.Email;
                                    clienteCadastrado.EnderecoRua = clienteBanco.EnderecoRua;
                                    clienteCadastrado.EnderecoNumero = clienteBanco.EnderecoNumero;
                                    clienteCadastrado.EnderecoBairro = clienteBanco.EnderecoBairro;
                                    clienteCadastrado.EnderecoComplemento = clienteBanco.EnderecoComplemento;
                                    clienteCadastrado.EnderecoCep = clienteBanco.EnderecoCep;
                                    clienteCadastrado.Telefone = clienteBanco.Telefone;
                                    clienteCadastrado.Contato = clienteBanco.Contato;
                                    await _clienteRepository.UpdateAsync(clienteCadastrado);
                                    await CadastraAtualizaTags(clienteCadastrado.Id, cliente.tags);
                                }
                            }
                            catch (Exception ex)
                            {

                                throw new UserFriendlyException("Ops!", ex.Message);
                            }

                        }
                    }
                }
            }   
        }

        private async Task IntegracaoOmieContratos()
        {
            int paginas = await RetornaTotalPgContratos();
            for (int i = 1; i <= paginas; i++)
            {
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://app.omie.com.br/api/v1/servicos/contrato/"))
                    {
                        request.Content = new StringContent("{\"call\":\"ListarContratos\",\"app_key\":\"38333295000\",\"app_secret\":\"4cea520a0e2a2ecdc267b75d3424a0ed\",\"param\":[{\"pagina\":"+i+",\"registros_por_pagina\":20,\"apenas_importado_api\":\"N\"}]}");
                        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                        var response = await httpClient.SendAsync(request);
                        var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        var contratos = JsonConvert.DeserializeObject<RespostaContrato>(jsonResult);
                        foreach (var contrato in contratos.contratoCadastro)
                        {  
                            foreach (var itens in contrato.itensContrato)
                            {
                                try
                                {
                                    Contrato input = new()
                                    {
                                        Id = itens.itemCabecalho.codItem,
                                        NumeroERP = contrato.cabecalho.nCodCli,
                                        Descricao = itens.itemDescrServ.descrCompleta,
                                        Quantidade = itens.itemCabecalho.quant
                                    };
                                    await DeleteContratos(itens.itemCabecalho.codItem);
                                    await _contratoRepository.InsertAsync(input);
                                }
                                catch (Exception ex)
                                {

                                    throw new UserFriendlyException("Ops!", ex.Message);
                                }                               
                            }
                        }
                    }
                }
            }
                
        }

        private static async Task<int> RetornaTotalPgContratos()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://app.omie.com.br/api/v1/servicos/contrato/"))
                {
                    request.Content = new StringContent("{\"call\":\"ListarContratos\",\"app_key\":\"38333295000\",\"app_secret\":\"4cea520a0e2a2ecdc267b75d3424a0ed\",\"param\":[{\"pagina\":1,\"registros_por_pagina\":20,\"apenas_importado_api\":\"N\"}]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var contratos = JsonConvert.DeserializeObject<RespostaContrato>(jsonResult);
                    return contratos.total_de_paginas;
                }
            }
        }

        private async Task DeleteContratos(long contratoId)
        {
            await _contratoRepository.DeleteAsync(contratoId);
        }

        private static async Task<int> RetornaTotalPgClientes()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://app.omie.com.br/api/v1/geral/clientes/"))
                {
                    request.Content = new StringContent("{\"call\":\"ListarClientesResumido\",\"app_key\":\"38333295000\",\"app_secret\":\"4cea520a0e2a2ecdc267b75d3424a0ed\",\"param\":[{\"pagina\":1,\"registros_por_pagina\":50,\"apenas_importado_api\":\"N\"}]}");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    var jsonResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var clientes = JsonConvert.DeserializeObject<Resposta>(jsonResult);
                    return clientes.total_de_paginas;
                }
            }
        }

        private async Task<int> RetornaCidade(string codigoIBGE)
        {
            var codigo = codigoIBGE;
            if (string.IsNullOrEmpty(codigo))
            {
                codigo = "412770";
            } else
            {
                codigo = codigo.Substring(0, codigo.Length - 1);
            }
            var cidadeId = await _cidadeRepository.FirstOrDefaultAsync(p => p.CodigoIBGE == Convert.ToInt32(codigo));
            return cidadeId.Id;
        }

        private async Task CadastraAtualizaTags(int clienteId, List<TagsCliente> tags)
        {
            await _tagClienteRepository.DeleteAsync(p => p.ClienteId == clienteId);

            foreach (var tag in tags)
            {
                var tagCadastrada = await _tagRepository.FirstOrDefaultAsync(p => p.Descricao == tag.tag);
                if (tagCadastrada == null)
                {
                    tagCadastrada = new Tag()
                    {
                        Descricao = tag.tag
                    };
                    var tagId = await _tagRepository.InsertAndGetIdAsync(tagCadastrada);
                    await VinculaTagCliente(clienteId, tagId);
                } else
                {
                    await VinculaTagCliente(clienteId, tagCadastrada.Id);
                }
            }
        }

        private async Task VinculaTagCliente(int clienteId, int tag)
        {
            TagCliente TagCliente = new()
            {
                Id = tag,
                ClienteId = clienteId
            };
            await _tagClienteRepository.InsertAsync(TagCliente);
        }

    }
}
