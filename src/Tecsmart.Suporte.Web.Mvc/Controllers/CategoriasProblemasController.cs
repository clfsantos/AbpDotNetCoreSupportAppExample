using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.CategoriasProblemas;
using Tecsmart.Suporte.Controllers;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CategoriasProblemasController : SuporteControllerBase
    {
        private readonly ICategoriaProblemaAppService _categoriaProblemaAppService;
        public CategoriasProblemasController(ICategoriaProblemaAppService categoriaProblemaAppService)
        {
            _categoriaProblemaAppService = categoriaProblemaAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllCategoriasProblemas(DataSourceLoadOptions loadOptions)
        {
            return await _categoriaProblemaAppService.GetAllForLoadResult(loadOptions);
        }

    }
}
