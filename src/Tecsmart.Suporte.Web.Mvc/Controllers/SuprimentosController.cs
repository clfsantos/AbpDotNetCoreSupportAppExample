using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Suprimentos;
using Tecsmart.Suporte.Suprimentos.Dto;
using Tecsmart.Suporte.Web.Models.Crachas;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SuprimentosController : SuporteControllerBase
    {
        private readonly ISuprimentoAppService _suprimentoAppService;
        private readonly ISuprimentoConsumoAppService _suprimentoConsumoAppService;

        public SuprimentosController(ISuprimentoAppService suprimentoAppService, ISuprimentoConsumoAppService suprimentoConsumoAppService)
        {
            _suprimentoAppService = suprimentoAppService;
            _suprimentoConsumoAppService = suprimentoConsumoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Consumo()
        {
            return View("Consumo/Index");
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllSuprimentos(DataSourceLoadOptions loadOptions)
        {
            return await _suprimentoAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllSuprimentosConsumo(DataSourceLoadOptions loadOptions)
        {
            return await _suprimentoConsumoAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetSuprimentoForEditOutput getSuprimentoForEditOutput;

            if (id.HasValue)
            {
                getSuprimentoForEditOutput = await _suprimentoAppService.GetSuprimentoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getSuprimentoForEditOutput = new GetSuprimentoForEditOutput
                {
                    Suprimento = new CreateOrEditSuprimentoDto()
                };
            }

            var viewModel = new CreateOrEditSuprimentoViewModel()
            {
                Suprimento = getSuprimentoForEditOutput.Suprimento
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalConsumo(int? id)
        {
            GetSuprimentoConsumoForEditOutput getSuprimentoConsumoForEditOutput;

            if (id.HasValue)
            {
                getSuprimentoConsumoForEditOutput = await _suprimentoConsumoAppService.GetSuprimentoConsumoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getSuprimentoConsumoForEditOutput = new GetSuprimentoConsumoForEditOutput
                {
                    SuprimentoConsumo = new CreateOrEditSuprimentoConsumoDto()
                };
            }

            var viewModel = new CreateOrEditSuprimentoConsumoViewModel()
            {
                SuprimentoConsumo = getSuprimentoConsumoForEditOutput.SuprimentoConsumo
            };

            return PartialView("Consumo/_CreateOrEditModal", viewModel);
        }

    }
}
