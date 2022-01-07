using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Produtos.Dto;

namespace Tecsmart.Suporte.Produtos
{
    [AbpAuthorize(PermissionNames.Pages_Produtos)]
    public class ProdutoAppService : SuporteAppServiceBase, IProdutoAppService
    {
        private readonly IRepository<Produto, int> _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoAppService(IRepository<Produto, int> produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        [AbpAuthorize(PermissionNames.Pages_Produtos)]
        public async Task<GetProdutoForEditOutput> GetProdutoForEdit(EntityDto<int> input)
        {
            var produto = await _produtoRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetProdutoForEditOutput { Produto = ObjectMapper.Map<CreateOrEditProdutoDto>(produto) };
            return output;
        }

        public async Task CreateOrEdit(CreateOrEditProdutoDto input)
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

        [AbpAuthorize(PermissionNames.Pages_Produtos_Create)]
        protected virtual async Task Create(CreateOrEditProdutoDto input)
        {
            var produto = ObjectMapper.Map<Produto>(input);
            await _produtoRepository.InsertAsync(produto);
        }

        [AbpAuthorize(PermissionNames.Pages_Produtos_Edit)]
        protected virtual async Task Update(CreateOrEditProdutoDto input)
        {
            var produto = await _produtoRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, produto);
        }

        [AbpAuthorize(PermissionNames.Pages_Produtos_Delete)]
        public async Task Delete(EntityDto<int> input)
        {
            await _produtoRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(PermissionNames.Pages_Produtos)]
        public async Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions)
        {
            var filteredProdutos = _produtoRepository.GetAll();
            return await Devex.DataSourceLoader.LoadDtoAsync<Produto, ProdutoDto>(_mapper, filteredProdutos, loadOptions);
        }

    }
}
