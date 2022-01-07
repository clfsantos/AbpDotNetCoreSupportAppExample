using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados;
using Tecsmart.Suporte.Chamados.Dto;
using Tecsmart.Suporte.Clientes;
using Tecsmart.Suporte.Clientes.Dto;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Web.Models.Chamados;
using Tecsmart.Suporte.Web.Models.Clientes;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class FluxoAtendimentosController : SuporteControllerBase
    {
        private readonly IFluxoAppService _fluxoAppService;
        public FluxoAtendimentosController(IFluxoAppService fluxoAppService)
        {
            _fluxoAppService = fluxoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult ReloadFluxo()
        {
            return ViewComponent("FluxoAtendimento");
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllFluxos(DataSourceLoadOptions loadOptions)
        {
            return await _fluxoAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetChamadoFluxoForEditOutput getChamadoFluxoForEditOutput;

            if (id.HasValue)
            {
                getChamadoFluxoForEditOutput = await _fluxoAppService.GetChamadoFluxoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getChamadoFluxoForEditOutput = new GetChamadoFluxoForEditOutput
                {
                    ChamadoFluxo = new CreateOrEditChamadoFluxoDto()
                };
            }

            var viewModel = new CreateOrEditFluxoViewModel()
            {
                ChamadoFluxo = getChamadoFluxoForEditOutput.ChamadoFluxo
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
