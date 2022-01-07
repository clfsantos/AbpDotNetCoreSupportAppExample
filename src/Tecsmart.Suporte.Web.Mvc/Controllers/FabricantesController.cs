using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Equipamentos.Fabricantes;
using Tecsmart.Suporte.Equipamentos.Fabricantes.Dto;
using Tecsmart.Suporte.Web.Models.Equipamentos.Fabricantes;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class FabricantesController : SuporteControllerBase
    {
        private readonly IFabricanteAppService _fabricanteAppService;
        public FabricantesController(IFabricanteAppService fabricanteAppService)
        {
            _fabricanteAppService = fabricanteAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllFabricantes(DataSourceLoadOptions loadOptions)
        {
            return await _fabricanteAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetFabricanteForEditOutput getFabricanteForEditOutput;

            if (id.HasValue)
            {
                getFabricanteForEditOutput = await _fabricanteAppService.GetFabricanteForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getFabricanteForEditOutput = new GetFabricanteForEditOutput
                {
                    Fabricante = new CreateOrEditFabricanteDto()
                };
            }

            var viewModel = new CreateOrEditFabricanteViewModel()
            {
                Fabricante = getFabricanteForEditOutput.Fabricante
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
