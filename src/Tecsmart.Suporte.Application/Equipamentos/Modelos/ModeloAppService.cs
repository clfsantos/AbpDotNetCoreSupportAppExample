using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Equipamentos.Modelos;
using Tecsmart.Suporte.Modelos.Dto;

namespace Tecsmart.Suporte.Modelos
{
    [AbpAuthorize(PermissionNames.Pages_Modelos)]
    public class ModeloAppService : SuporteAppServiceBase, IModeloAppService
    {
        private readonly IRepository<Modelo, int> _modeloRepository;
        private readonly IMapper _mapper;

        public ModeloAppService(IRepository<Modelo, int> modeloRepository, IMapper mapper)
        {
            _modeloRepository = modeloRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Modelos)]
        public async Task<GetModeloForEditOutput> GetModeloForEdit(EntityDto<int> input)
        {
            var modelo = await _modeloRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetModeloForEditOutput { Modelo = ObjectMapper.Map<CreateOrEditModeloDto>(modelo) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditModeloDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Modelos_Create)]
        protected virtual async Task Create(CreateOrEditModeloDto input)
        {
            var modelo = ObjectMapper.Map<Modelo>(input);
            await _modeloRepository.InsertAsync(modelo);
        }

        [AbpAuthorize(PermissionNames.Pages_Modelos_Edit)]
        protected virtual async Task Update(CreateOrEditModeloDto input)
        {
            var modelo = await _modeloRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, modelo);
        }

        [AbpAuthorize(PermissionNames.Pages_Modelos_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            await _modeloRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Modelos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredModelos = _modeloRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Modelo, ModeloDto>(_mapper, filteredModelos, loadOptions);
        }

    }
}
