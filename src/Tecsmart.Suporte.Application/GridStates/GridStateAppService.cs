using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.GridStates.Dto;

namespace Tecsmart.Suporte.GridStates
{
    [AbpAuthorize]
    public class GridStateAppService : SuporteAppServiceBase, IGridStateAppService
    {
        private readonly IRepository<GridState, int> _gridStateRepository;
        private readonly IMapper _mapper;
        private readonly IAbpSession _session;

        public GridStateAppService(IRepository<GridState, int> gridStateRepository, IMapper mapper, IAbpSession session)
        {
            _gridStateRepository = gridStateRepository;
            _mapper = mapper;
            _session = session;
        }

        public async Task<GetGridStateForEditOutput> GetGridStateForEdit(EntityDto<int> input)
        {
            var gridState = await _gridStateRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetGridStateForEditOutput { GridState = ObjectMapper.Map<CreateOrEditGridStateDto>(gridState) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditGridStateDto input)
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

        protected virtual async Task Create(CreateOrEditGridStateDto input)
        {
            var gridState = ObjectMapper.Map<GridState>(input);
            await _gridStateRepository.InsertAsync(gridState);
        }

        protected virtual async Task Update(CreateOrEditGridStateDto input)
        {
            var gridState = await _gridStateRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, gridState);
        }

        public async Task Delete(EntityDto<int> input)
        {
            await _gridStateRepository.DeleteAsync(input.Id);
        }

        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions, string tela)
        {
            var filteredGridStates = _gridStateRepository.GetAll().Where(p => p.Tela == tela && p.UsuarioId == _session.UserId);
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<GridState, GridStateDto>(_mapper, filteredGridStates, loadOptions);
        }

    }
}
