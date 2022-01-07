using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Equipamentos.Categorias;
using Tecsmart.Suporte.Equipamentos.Categorias.Dto;
using Tecsmart.Suporte.Web.Models.Equipamentos.Categorias;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CategoriasController : SuporteControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;
        public CategoriasController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllCategorias(DataSourceLoadOptions loadOptions)
        {
            return await _categoriaAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetCategoriaForEditOutput getCategoriaForEditOutput;

            if (id.HasValue)
            {
                getCategoriaForEditOutput = await _categoriaAppService.GetCategoriaForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getCategoriaForEditOutput = new GetCategoriaForEditOutput
                {
                    Categoria = new CreateOrEditCategoriaDto()
                };
            }

            var viewModel = new CreateOrEditCategoriaViewModel()
            {
                Categoria = getCategoriaForEditOutput.Categoria
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
