using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Chamados.Dto;
using Tecsmart.Suporte.OnSignal;

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class ImplantacaoAppService : SuporteAppServiceBase, IImplantacaoAppService
    {
        private readonly IRepository<EtapaChamado, int> _etapaChamadoRepository;
        private readonly IRepository<Etapa, int> _etapaRepository;
        private readonly IRepository<EtapaView, int> _etapaViewRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public ImplantacaoAppService(IRepository<EtapaChamado, int> etapaChamadoRepository,
                                     IRepository<Etapa, int> etapaRepository,
                                     IRepository<EtapaView, int> etapaViewRepository,
                                     IMapper mapper,
                                     IAbpSession session)
        {
            _etapaChamadoRepository = etapaChamadoRepository;
            _etapaRepository = etapaRepository;
            _etapaViewRepository = etapaViewRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetEtapaChamadoForEditOutput> GetEtapaChamadoForEdit(EntityDto<int> input)
        {
            var etapaChamado = await _etapaChamadoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetEtapaChamadoForEditOutput { EtapaChamado = ObjectMapper.Map<CreateOrEditEtapaChamadoDto>(etapaChamado) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditEtapaChamadoDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Create(CreateOrEditEtapaChamadoDto input)
        {
            var etapaChamado = ObjectMapper.Map<EtapaChamado>(input);
            await _etapaChamadoRepository.InsertAsync(etapaChamado);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Update(CreateOrEditEtapaChamadoDto input)
        {
            var etapaChamado = await _etapaChamadoRepository.FirstOrDefaultAsync((int)input.Id);
            if (etapaChamado.EtapaStatusId == 1)
                throw new UserFriendlyException("Esta etapa já está concluída!");
            etapaChamado.Observacao = input.Observacao;
            await _etapaChamadoRepository.UpdateAsync(etapaChamado);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task RecusarEtapaChamado(CreateOrEditEtapaChamadoDto input)
        {
            var etapaChamado = _etapaChamadoRepository.GetAllIncluding(p => p.EtapaFk).FirstOrDefault(p => p.Id == input.Id);
            if (!await VerificaPermissaoSetorProxima(etapaChamado.EtapaFk.Sequencia + 1))
                throw new UserFriendlyException("Somente o setor responsável pode recusar a etapa!");
            etapaChamado.ObsRecusada = input.ObsRecusada;
            etapaChamado.EtapaStatusId = 4;
            etapaChamado.DataRecusada = DateTime.Now;
            await _etapaChamadoRepository.UpdateAsync(etapaChamado);
            var novaEtapaChamado = new EtapaChamado
            {
                ChamadoId = etapaChamado.ChamadoId,
                EtapaId = etapaChamado.EtapaFk.Id,
                EtapaStatusId = 2,
                DataEtapa = DateTime.Now
            };
            await _etapaChamadoRepository.InsertAsync(novaEtapaChamado);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task AprovarConcluirEtapa(EntityDto<int> input)
        {
            var etapaChamado = _etapaChamadoRepository.GetAllIncluding(p => p.EtapaFk).FirstOrDefault(p => p.Id == input.Id);

            if (etapaChamado.EtapaStatusId == 1)
                throw new UserFriendlyException("Esta etapa já está concluída!");
            else if (etapaChamado.EtapaStatusId == 4)
                throw new UserFriendlyException("Esta etapa foi recusada e não pode ser aprovada!");
            if (etapaChamado.EtapaStatusId == 2)
            {
                if (!VerificaPermissaoSetorAtual(etapaChamado))
                    throw new UserFriendlyException("Somente o setor responsável pode concluir a etapa!");
                etapaChamado.EtapaStatusId = 3;
                await NotificaSetorProxima(etapaChamado.EtapaFk.Sequencia + 1, 2);
            }
            else
            {
                if (!await VerificaPermissaoSetorProxima(etapaChamado.EtapaFk.Sequencia + 1))
                    throw new UserFriendlyException("Somente o setor responsável pode aprovar a etapa!");
                etapaChamado.EtapaStatusId = 1;
                etapaChamado.DataConclusao = DateTime.Now;
                await NotificaSetorProxima(etapaChamado.EtapaFk.Sequencia + 1, 1);
            }

            await _etapaChamadoRepository.UpdateAsync(etapaChamado);

            if (etapaChamado.EtapaStatusId == 1)
            {
                var etapa = await _etapaRepository.FirstOrDefaultAsync(p => p.Sequencia == etapaChamado.EtapaFk.Sequencia + 1);
                if (etapa != null)
                {
                    var novaEtapaChamado = new EtapaChamado
                    {
                        ChamadoId = etapaChamado.ChamadoId,
                        EtapaId = etapa.Id,
                        EtapaStatusId = 2,
                        DataEtapa = DateTime.Now
                    };
                    await _etapaChamadoRepository.InsertAsync(novaEtapaChamado);
                }
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            var filteredEtapasChamado = _etapaChamadoRepository.GetAll().Where(p => p.ChamadoId == chamadoId);
            return await Devex.DataSourceLoader.LoadDtoAsync<EtapaChamado, EtapaChamadoDto>(_mapper, filteredEtapasChamado, loadOptions);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetEtapasAbertasPendentes(DataSourceLoadOptions loadOptions)
        {
            var filteredEtapas = _etapaViewRepository.GetAll().Where(p => EF.Functions.Like(p.SetorResponsavel, $"%,{_session.UserId},%"));
            var resultado = await Devex.DataSourceLoader.LoadDtoAsync<EtapaView, EtapaViewDto>(_mapper, filteredEtapas, loadOptions);
            return resultado;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetEtapasAbertasPendentesGeral(DataSourceLoadOptions loadOptions)
        {
            var filteredEtapas = _etapaViewRepository.GetAll();
            var resultado = await Devex.DataSourceLoader.LoadDtoAsync<EtapaView, EtapaViewDto>(_mapper, filteredEtapas, loadOptions);
            return resultado;
        }

        private bool VerificaPermissaoSetorAtual(EtapaChamado etapaChamado)
        {
            var usuario = (int)_session.UserId;

            string s = etapaChamado.EtapaFk.SetorResponsavel;
            string[] A = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = A.Select(x => Convert.ToInt32(x)).ToArray();

            if (numbers.Contains(usuario))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<bool> VerificaPermissaoSetorProxima(int sequencia)
        {
            var etapa = await _etapaRepository.FirstOrDefaultAsync(p => p.Sequencia == sequencia);
            if (etapa == null) return true;
            var usuario = (int)_session.UserId;

            string s = etapa.SetorResponsavel;
            string[] A = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = A.Select(x => Convert.ToInt32(x)).ToArray();

            if (numbers.Contains(usuario))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task NotificaSetorProxima(int sequencia, int etapaId)
        {
            var etapa = await _etapaRepository.FirstOrDefaultAsync(p => p.Sequencia == sequencia);
            if (etapa == null) return;

            string s = etapa.SetorResponsavel;
            string[] A = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = A.Select(x => Convert.ToInt32(x)).ToArray();

            if (etapaId == 2)
            {
                foreach (int number in numbers)
                {
                    OneSignalService.SendPush((long)number, "Etapa pendente de aprovação!", "Você tem uma nova etapa pendente de aprovação.", "http://10.0.0.251/");
                }
            }
            else
            {
                foreach (int number in numbers)
                {
                    OneSignalService.SendPush((long)number, "Nova etapa de implantação!", "Você tem uma nova etapa a cumprir na implantação.", "http://10.0.0.251/");
                }
            }


        }

    }
}