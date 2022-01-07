using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Produtos;
using Tecsmart.Suporte.Produtos.Dto;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Web.Models.Produtos;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProdutosController : SuporteControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IGrupoAppService _grupoAppService;
        private readonly ISubGrupoAppService _subGrupoAppService;
        public ProdutosController(IProdutoAppService produtoAppService,
                                  IGrupoAppService grupoAppService,
                                  ISubGrupoAppService subGrupoAppService)
        {
            _produtoAppService = produtoAppService;
            _grupoAppService = grupoAppService;
            _subGrupoAppService = subGrupoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllProdutos(DataSourceLoadOptions loadOptions)
        {
            return await _produtoAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllGrupos(DataSourceLoadOptions loadOptions)
        {
            return await _grupoAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllSubGrupos(DataSourceLoadOptions loadOptions)
        {
            return await _subGrupoAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetProdutoForEditOutput getProdutoForEditOutput;

            if (id.HasValue)
            {
                getProdutoForEditOutput = await _produtoAppService.GetProdutoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getProdutoForEditOutput = new GetProdutoForEditOutput
                {
                    Produto = new CreateOrEditProdutoDto()
                };
            }

            var viewModel = new CreateOrEditProdutoViewModel()
            {
                Produto = getProdutoForEditOutput.Produto
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
