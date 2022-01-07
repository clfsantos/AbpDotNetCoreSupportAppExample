using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class AssistenciaAppService : SuporteAppServiceBase, IAssistenciaAppService
    {
        private readonly IRepository<Assistencia, int> _assistenciaRepository;
        //private readonly IRepository<Chamado, int> _chamadoRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public AssistenciaAppService(IRepository<Assistencia, int> assistenciaRepository,
                                            
                                            IMapper mapper, 
                                            IAbpSession session)
        {
            _assistenciaRepository = assistenciaRepository;
           
            _mapper = mapper;
            _session = session;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetAssistenciaForEditOutput> GetAssistenciaForEdit(EntityDto<int> input)
        {
            var assistencia = await _assistenciaRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetAssistenciaForEditOutput { Assistencia = ObjectMapper.Map<CreateOrEditAssistenciaDto>(assistencia) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditAssistenciaDto input)
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
        protected virtual async Task Create(CreateOrEditAssistenciaDto input)
        {
            var assistencia = ObjectMapper.Map<Assistencia>(input);
            await _assistenciaRepository.InsertAsync(assistencia);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Update(CreateOrEditAssistenciaDto input)
        {
            var assistencia = await _assistenciaRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, assistencia);
        }

        //[AbpAuthorize(PermissionNames.Pages_Chamados)]
        //public async Task Cancelar(EntityDto<int> input)
        //{
        //    var tarefa = await _tarefaRepository.FirstOrDefaultAsync(input.Id);
        //    if(tarefa.Status == true)
        //    {
        //        throw new UserFriendlyException("Ops!", "Tarefas já concluídas não podem ser canceladas!");
        //    } else if (tarefa.Cancelada == true)
        //    {
        //        throw new UserFriendlyException("Ops!", "Essa tarefa já está cancelada!");
        //    }
        //    tarefa.Cancelada = true;
        //    await _tarefaRepository.UpdateAsync(tarefa);
        //}

        public async Task<AssistenciaDto> GetAssistencia(int? chamadoId)
        {
            if (chamadoId.HasValue)
            {
                var filteredAssistencias = _assistenciaRepository.GetAll().Where(p => p.ChamadoId == chamadoId);
                var assistencia = await Devex.DataSourceLoader.LoadDtoAsync<Assistencia, AssistenciaDto>(_mapper, filteredAssistencias, new DataSourceLoadOptions());
                var dados = assistencia.data.GetEnumerator();
                
                if (!dados.MoveNext()) return null;

                dados.Reset();
                dados.MoveNext();
                return (AssistenciaDto)dados.Current;
            } else
            {
                return null;
            }
            
        }

        public async Task<List<AssistenciaDto>> GetAssistenciasAbertas()
        {
            var filteredAssistencias = _assistenciaRepository.GetAll().Where(p => p.ChamadoFk.ClassificacaoId == 9 && p.ChamadoFk.Status == 1);
            var assistencias = await Devex.DataSourceLoader.LoadDtoAsync<Assistencia, AssistenciaDto>(_mapper, filteredAssistencias, new DataSourceLoadOptions());
            var dados = assistencias.data;
            return (List<AssistenciaDto>)dados;
        }

        public async Task<LoadResult> GetAssistenciasAbertas(DataSourceLoadOptions loadOptions)
        {
            var filteredAssistencias = _assistenciaRepository.GetAll().Where(p => p.ChamadoFk.ClassificacaoId == 9 && p.ChamadoFk.Status == 1);
            return await Devex.DataSourceLoader.LoadDtoAsync<Assistencia, AssistenciaDto>(_mapper, filteredAssistencias, loadOptions);
        }

        //private async Task TransferirChamado(CreateOrEditTarefaDto input)
        //{
        //    var chamado = await _chamadoRepository.FirstOrDefaultAsync((int)input.ChamadoId);
        //    chamado.ResponsavelAtualId = (long)input.UsuarioAtribuidoId;
        //    await _chamadoRepository.UpdateAsync(chamado);
        //}

        //[AbpAuthorize(PermissionNames.Pages_Chamados)]
        //public AssistenciaDto GetAssistencia(int? chamadoId)
        //{
        //    if(chamadoId.HasValue)
        //    {
        //        var assistencia = _assistenciaRepository.GetAll().Include(e => e.EquipamentoFk).Include(c => c.ChamadoFk).Include(c => c.ChamadoFk.ClienteFk).Where(x => x.ChamadoId == chamadoId).FirstOrDefault();
        //        var output = ObjectMapper.Map<AssistenciaDto>(assistencia);
        //        return output;
        //    } else
        //    {
        //        return null;
        //    }

        //}

    }
}
