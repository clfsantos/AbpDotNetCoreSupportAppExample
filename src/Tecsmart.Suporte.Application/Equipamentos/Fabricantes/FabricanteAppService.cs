using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Equipamentos.Fabricantes.Dto;

namespace Tecsmart.Suporte.Equipamentos.Fabricantes
{
    [AbpAuthorize(PermissionNames.Pages_Fabricantes)]
    public class FabricanteAppService : SuporteAppServiceBase, IFabricanteAppService
    {
        private readonly IRepository<Fabricante, int> _fabricanteRepository;
        private readonly IMapper _mapper;

        public FabricanteAppService(IRepository<Fabricante, int> fabricanteRepository, IMapper mapper)
        {
            _fabricanteRepository = fabricanteRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Fabricantes)]
        public async Task<GetFabricanteForEditOutput> GetFabricanteForEdit(EntityDto<int> input)
        {
            var fabricante = await _fabricanteRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetFabricanteForEditOutput { Fabricante = ObjectMapper.Map<CreateOrEditFabricanteDto>(fabricante) };
            return output;
        }

        public async Task<int> CreateOrEdit(CreateOrEditFabricanteDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Fabricantes_Create)]
        protected virtual async Task<int> Create(CreateOrEditFabricanteDto input)
        {
            var fabricante = ObjectMapper.Map<Fabricante>(input);
            return await _fabricanteRepository.InsertAndGetIdAsync(fabricante);
        }

        [AbpAuthorize(PermissionNames.Pages_Fabricantes_Edit)]
        protected virtual async Task Update(CreateOrEditFabricanteDto input)
        {
            var equipamento = await _fabricanteRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, equipamento);
        }

        [AbpAuthorize(PermissionNames.Pages_Fabricantes_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            await _fabricanteRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Fabricantes)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredFabricantes = _fabricanteRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Fabricante, FabricanteDto>(_mapper, filteredFabricantes, loadOptions);
        }

    }
}
