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

namespace Tecsmart.Suporte.Chamados
{
    [AbpAuthorize(PermissionNames.Pages_Chamados)]
    public class FluxoAppService : SuporteAppServiceBase, IFluxoAppService
    {
        private readonly IRepository<ChamadoFluxo, int> _chamadoFluxoRepository;
        private readonly IMapper _mapper;
        
        public FluxoAppService(IRepository<ChamadoFluxo, int> chamadoFluxoRepository, IMapper mapper)
        {
            _chamadoFluxoRepository = chamadoFluxoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        public async Task<GetChamadoFluxoForEditOutput> GetChamadoFluxoForEdit(EntityDto<int> input)
        {
            var chamadoFluxo = await _chamadoFluxoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetChamadoFluxoForEditOutput { ChamadoFluxo = ObjectMapper.Map<CreateOrEditChamadoFluxoDto>(chamadoFluxo) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditChamadoFluxoDto input)
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
        protected virtual async Task Create(CreateOrEditChamadoFluxoDto input)
        {
            var chamadoFluxo = ObjectMapper.Map<ChamadoFluxo>(input);
            await _chamadoFluxoRepository.InsertAsync(chamadoFluxo);
        }

        [AbpAuthorize(PermissionNames.Pages_Chamados)]
        protected virtual async Task Update(CreateOrEditChamadoFluxoDto input)
        {
            var chamadoFluxo = await _chamadoFluxoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, chamadoFluxo);
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

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredFluxo = _chamadoFluxoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<ChamadoFluxo, ChamadoFluxoDto>(_mapper, filteredFluxo, loadOptions);
        }

    }
}
