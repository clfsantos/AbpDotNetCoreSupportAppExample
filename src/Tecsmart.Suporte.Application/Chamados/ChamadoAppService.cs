using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Chamados.ChartsDto;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class ChamadoAppService : SuporteAppServiceBase, IChamadoAppService
    {
        private readonly IRepository<Chamado, int> _chamadoRepository;
        private readonly IRepository<ChamadoView, int> _chamadoViewRepository;
        private readonly IRepository<PrioridadeFluxoView, int> _prioridadeFluxoViewRepository;
        private readonly IRepository<EtapaChamado, int> _etapaChamadoRepository;
        private readonly IRepository<Assistencia, int> _assistenciaRepository;
        private readonly IRepository<Tarefa, int> _tarefaRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public ChamadoAppService(IRepository<Chamado, int> chamadoRepository,
                                 IRepository<ChamadoView, int> chamadoViewRepository,
                                 IRepository<PrioridadeFluxoView, int> prioridadeFluxoViewRepository,
                                 IRepository<EtapaChamado, int> etapaChamadoRepository,
                                 IRepository<Assistencia, int> assistenciaRepository,
                                 IRepository<Tarefa, int> tarefaRepository,
                                 IMapper mapper,
                                 IAbpSession session)
        {
            _chamadoRepository = chamadoRepository;
            _chamadoViewRepository = chamadoViewRepository;
            _prioridadeFluxoViewRepository = prioridadeFluxoViewRepository;
            _etapaChamadoRepository = etapaChamadoRepository;
            _assistenciaRepository = assistenciaRepository;
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<List<PrioridadeFluxoViewDto>> ObterListaPrioridadeFluxo()
        {
            var lista = await _prioridadeFluxoViewRepository.GetAllIncluding(u => u.UsuarioFk).OrderBy(p => p.UltimoAtendimento).ThenBy(p => p.PrioridadeId).ToListAsync();
            return ObjectMapper.Map<List<PrioridadeFluxoViewDto>>(lista);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetChamadoForEditOutput> GetChamadoForEdit(EntityDto<int> input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetChamadoForEditOutput { Chamado = ObjectMapper.Map<CreateOrEditChamadoDto>(chamado) };
            return output;
        }

        public async Task<int> CreateOrEdit(CreateOrEditChamadoDto input)
        {
            if (input.Id == null)
            {
                return await Create(input);
            }
            else
            {
                await Update(input);
                return (int)input.Id;
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task<int> Create(CreateOrEditChamadoDto input)
        {
            var chamado = ObjectMapper.Map<Chamado>(input);
            chamado.ResponsavelId = (long)_session.UserId;
            chamado.ResponsavelAtualId = chamado.ResponsavelId;
            if (input.FinalizarChamado)
            {
                if (chamado.GrupoId == null || chamado.SubGrupoId == null || string.IsNullOrEmpty(input.ParecerFinal))
                    throw new UserFriendlyException("Ops!", "Campos obrigatórios no fechamento não foram preenchidos, verifique o grupo, sub-grupo e o parecer final.");

                chamado.Status = 2;
                chamado.ChamadoAberto = false;
                chamado.DataEncerramento = DateTime.Now;
                chamado.ResponsavelFechamentoId = (long)_session.UserId;

                if (input.ClassificacaoId == 9)
                {
                    throw new UserFriendlyException("Chamados classificados como Assistência devem obrigatoriamente ter um equipamento vinculado antes de serem encerrados!");
                }

                if (input.ClassificacaoId == 3)
                {
                    throw new UserFriendlyException("Antes de encerrar um chamado de implantação todas as etapas devem estar concluídas, se for o caso, faça o cancelamento do chamado!");
                }

            } else
            {
                chamado.ChamadoAberto = true;
            }
            
            var chamadoId = await _chamadoRepository.InsertAndGetIdAsync(chamado);

            if (input.ClassificacaoId == 3)
            {
                var etapaChamado = new EtapaChamado {
                    ChamadoId = chamadoId,
                    EtapaId = 3,
                    EtapaStatusId = 2,
                    DataEtapa = DateTime.Now
                };
                await _etapaChamadoRepository.InsertAsync(etapaChamado);
            }
            return chamadoId;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Update(CreateOrEditChamadoDto input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync((int)input.Id);
            if (input.FinalizarChamado)
            {
                if (input.GrupoId == null || input.SubGrupoId == null || string.IsNullOrEmpty(input.ParecerFinal))
                    throw new UserFriendlyException("Ops!", "Campos obrigatórios no fechamento não foram preenchidos, verifique o grupo, sub-grupo e o parecer final.");

                input.Status = 2;
                input.ChamadoAberto = false;
                input.DataEncerramento = DateTime.Now;
                input.ResponsavelFechamentoId = (int)_session.UserId;

                if (input.ClassificacaoId == 9)
                {
                    var assistencia = await _assistenciaRepository.FirstOrDefaultAsync(p => p.ChamadoId == input.Id);
                    if (assistencia == null)
                    {
                        throw new UserFriendlyException("Chamados classificados como Assistência devem obrigatoriamente ter um equipamento vinculado antes de serem encerrados!");
                    }
                }

                if (input.ClassificacaoId == 3)
                {
                    var etapaChamado = await _etapaChamadoRepository.FirstOrDefaultAsync(p => p.ChamadoId == input.Id && (p.EtapaStatusId == 2 || p.EtapaStatusId == 3));
                    if (etapaChamado != null)
                    {
                        throw new UserFriendlyException("Antes de encerrar um chamado de implantação todas as etapas devem estar concluídas, se for o caso, faça o cancelamento do chamado!");
                    }
                }

                var tarefa = await _tarefaRepository.FirstOrDefaultAsync(p => p.ChamadoId == input.Id && p.StatusId == 2);
                if (tarefa != null)
                {
                    throw new UserFriendlyException("Este chamado ainda tem tarefas em aberto, antes do encerramento devem ser concuídas ou canceladas!");
                }

            } else
            {
                input.ChamadoAberto = true;
            }
            ObjectMapper.Map(input, chamado);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        [UnitOfWork]
        public async Task Cancelar(EntityDto<int> input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync(input.Id);
            if (chamado.ResponsavelAtualId != (long)_session.UserId)
            {
                throw new UserFriendlyException("Ops!", "O chamado só pode ser cancelado pelo responsável atual, se precisar, assuma o chamado primeiro!");
            }
            chamado.Status = 3;
            chamado.ChamadoCancelado = true;
            await _chamadoRepository.UpdateAsync(chamado);

            await _etapaChamadoRepository.DeleteAsync(p => p.ChamadoId == input.Id && p.EtapaStatusId != 1);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task Assumir(CreateOrEditChamadoDto input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync((int)input.Id);
            chamado.ResponsavelAtualId = (long)_session.UserId;
            await _chamadoRepository.UpdateAsync(chamado);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredChamados = _chamadoViewRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<ChamadoView, ChamadoViewDto>(_mapper, filteredChamados, loadOptions);
        }

        public async Task<LoadResult> GetAllForRelatorioLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredChamados = _chamadoRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Chamado, ChamadoDto>(_mapper, filteredChamados, loadOptions);
        }

        public async Task<LoadResult> GetAllForRelatorioAssistenciaLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredAssistencias = _assistenciaRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Assistencia, AssistenciaDto>(_mapper, filteredAssistencias, loadOptions);
        }

        //[AbpAuthorize(PermissionNames.Pages_Chamados)]
        //public List<ChamadosDiaDto> GetChamadosDia()
        //{
        //    var chamados = _chamadoRepository.GetAll().GroupBy(x => x.DataAbertura.Date).Select(p => new ChamadosDiaDto()
        //    {
        //        DataAbertura = p.Key.Date,
        //        Quantidade = p.Count()
        //    }).ToList();

        //    return chamados;
        //}

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetChamadosDia(DataSourceLoadOptions loadOptions)
        {
            var chamados = _chamadoRepository.GetAll().GroupBy(x => x.DataAbertura.Date).OrderBy(x => x.Key.Date).Select(p => new ChamadosDiaDto()
            {
                DataAbertura = p.Key.Date,
                Quantidade = p.Count()
            });

            var resultado = await DataSourceLoader.LoadAsync(chamados, loadOptions);
            return resultado;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetChamadosAno(DataSourceLoadOptions loadOptions)
        {
            var chamados = _chamadoRepository.GetAll().GroupBy(x => x.DataAbertura.Date.Year).OrderBy(x => x.Key).Select(p => new ChamadosAnoDto()
            {
                Ano = p.Key,
                Quantidade = p.Count()
            });

            var resultado = await DataSourceLoader.LoadAsync(chamados, loadOptions);
            return resultado;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetChamadosMes(DataSourceLoadOptions loadOptions)
        {
            int ano = Convert.ToInt32(loadOptions.Filter[2]);
            loadOptions.Filter.Clear();
            var chamados = _chamadoRepository.GetAll().Where(x => x.DataAbertura.Date.Year == ano).GroupBy(x => x.DataAbertura.Date.Month).OrderBy(x => x.Key).Select(p => new ChamadosAnoDto()
            {
                Ano = p.Key,
                Quantidade = p.Count()
            });

            var resultado = await DataSourceLoader.LoadAsync(chamados, loadOptions);
            return resultado;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<LoadResult> GetChamadosTecnico(DataSourceLoadOptions loadOptions)
        {
            var chamados = _chamadoRepository.GetAll();
            loadOptions.RemoteGrouping = true;
            loadOptions.RequireGroupCount = true;
            loadOptions.RequireTotalCount = true;
            loadOptions.Group = new[] { new GroupingInfo { Selector = "ResponsavelFkName", IsExpanded = false } };
            loadOptions.GroupSummary = new[] { new SummaryInfo { Selector = "ResponsavelFkName", SummaryType = "count" } };
            //var resultado = await DataSourceLoader.LoadAsync(chamados, loadOptions);
            //return resultado;
            //var chamados = _chamadoRepository.GetAll();
            //var grupo = new SummaryInfo();
            //grupo.Selector = "responsavelFkName";
            //grupo.SummaryType = "sum";
            //loadOptions.GroupSummary = new SummaryInfo[] { grupo };
            var resultado = await Devex.DataSourceLoader.LoadDtoAsync<Chamado, ChamadosTecnicoDto>(_mapper, chamados, loadOptions);
            return resultado;

            //var chamados = _chamadoRepository.GetAll().Where(p => p.DataAbertura > DateTime.Now.AddDays(-30)).GroupBy(x => x.ResponsavelFk.Name).Select(p => new ChamadosTecnicoDto()
            //{
            //    ResponsavelFkName = p.Key.ToString(),
            //    Quantidade = p.Count()
            //});

            //var resultado = await DataSourceLoader.LoadAsync(chamados, loadOptions);
            //return resultado;
            ////return new LoadResult();
        }

    }
}
