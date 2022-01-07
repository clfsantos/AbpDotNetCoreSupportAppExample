using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Equipamentos.Categorias.Dto;

namespace Tecsmart.Suporte.Equipamentos.Categorias
{
    [AbpAuthorize(PermissionNames.Pages_Categorias)]
    public class CategoriaAppService : SuporteAppServiceBase, ICategoriaAppService
    {
        private readonly IRepository<Categoria, int> _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaAppService(IRepository<Categoria, int> categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Categorias)]
        public async Task<GetCategoriaForEditOutput> GetCategoriaForEdit(EntityDto<int> input)
        {
            var categoria = await _categoriaRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetCategoriaForEditOutput { Categoria = ObjectMapper.Map<CreateOrEditCategoriaDto>(categoria) };
            return output;
        }

        public async Task<int> CreateOrEdit(CreateOrEditCategoriaDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Categorias_Create)]
        protected virtual async Task<int> Create(CreateOrEditCategoriaDto input)
        {
            var categoria = ObjectMapper.Map<Categoria>(input);
            return await _categoriaRepository.InsertAndGetIdAsync(categoria);
        }

        [AbpAuthorize(PermissionNames.Pages_Categorias_Edit)]
        protected virtual async Task Update(CreateOrEditCategoriaDto input)
        {
            var categoria = await _categoriaRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, categoria);
        }

        [AbpAuthorize(PermissionNames.Pages_Categorias_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            await _categoriaRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Categorias)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredCategorias = _categoriaRepository.GetAll();
            loadOptions.StringToLower = true;
            return await Devex.DataSourceLoader.LoadDtoAsync<Categoria, CategoriaDto>(_mapper, filteredCategorias, loadOptions);
        }

    }
}
