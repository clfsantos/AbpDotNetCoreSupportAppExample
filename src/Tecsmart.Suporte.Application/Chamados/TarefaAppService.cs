using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Chamados.Dto;
using Tecsmart.Suporte.OnSignal;

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class TarefaAppService : SuporteAppServiceBase, ITarefaAppService
    {
        private readonly IRepository<Tarefa, int> _tarefaRepository;
        private readonly IRepository<Chamado, int> _chamadoRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public TarefaAppService(IRepository<Tarefa, int> tarefaRepository,
                                            IRepository<Chamado, int> chamadoRepository,
                                            IMapper mapper, 
                                            IAbpSession session)
        {
            _tarefaRepository = tarefaRepository;
            _chamadoRepository = chamadoRepository;
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetTarefaForEditOutput> GetTarefaForEdit(EntityDto<int> input)
        {
            var tarefa = await _tarefaRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetTarefaForEditOutput { Tarefa = ObjectMapper.Map<CreateOrEditTarefaDto>(tarefa) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditTarefaDto input)
        {
            input.UsuarioId = (long)_session.UserId;
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
        protected virtual async Task Create(CreateOrEditTarefaDto input)
        {
            var tarefa = ObjectMapper.Map<Tarefa>(input);
            if (input.Status == true)
            {
                tarefa.StatusId = 1;
            } else
            {
                tarefa.StatusId = 2;
            }
            if (input.Cancelada == true)
            {
                tarefa.StatusId = 3;
            }
            await _tarefaRepository.InsertAsync(tarefa);
            OneSignalService.SendPush((long)input.UsuarioAtribuidoId, "Novo Agendamento!", "Você teve um novo agendamento", "http://10.0.0.251/Agenda");
            if (input.TransferirChamado)
            {
                await TransferirChamado(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Update(CreateOrEditTarefaDto input)
        {
            var tarefa = await _tarefaRepository.FirstOrDefaultAsync((int)input.Id);
            if (input.Status == true)
            {
                tarefa.StatusId = 1;
            }
            else
            {
                tarefa.StatusId = 2;
            }
            if (input.Cancelada == true)
            {
                tarefa.StatusId = 3;
            }
            ObjectMapper.Map(input, tarefa);

            if (input.TransferirChamado)
            {
                await TransferirChamado(input);
            }
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task Cancelar(EntityDto<int> input)
        {
            var tarefa = await _tarefaRepository.FirstOrDefaultAsync(input.Id);
            if(tarefa.Status == true)
            {
                throw new UserFriendlyException("Ops!", "Tarefas já concluídas não podem ser canceladas!");
            } else if (tarefa.Cancelada == true)
            {
                throw new UserFriendlyException("Ops!", "Essa tarefa já está cancelada!");
            }
            tarefa.Cancelada = true;
            tarefa.StatusId = 3;
            await _tarefaRepository.UpdateAsync(tarefa);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, int chamadoId)
        {
            var filteredTarefas = _tarefaRepository.GetAll().Where(p => p.ChamadoId == chamadoId);
            return await Devex.DataSourceLoader.LoadDtoAsync<Tarefa, TarefaDto>(_mapper, filteredTarefas, loadOptions);
        }

        public async Task<LoadResult> GetAllForAgendaLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredTarefas = _tarefaRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Tarefa, TarefaDto>(_mapper, filteredTarefas, loadOptions);
        }

        private async Task TransferirChamado(CreateOrEditTarefaDto input)
        {
            var chamado = await _chamadoRepository.FirstOrDefaultAsync((int)input.ChamadoId);
            chamado.ResponsavelAtualId = (long)input.UsuarioAtribuidoId;
            await _chamadoRepository.UpdateAsync(chamado);
        }

    }
}
