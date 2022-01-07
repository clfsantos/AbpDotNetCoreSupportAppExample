using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Crachas;
using Tecsmart.Suporte.Crachas.Dto;
using Tecsmart.Suporte.Web.Models.Crachas;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class CrachasController : SuporteControllerBase
    {
        private readonly ICrachaAppService _crachaAppService;
        public CrachasController(ICrachaAppService crachaAppService)
        {
            _crachaAppService = crachaAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult CarregaCrachasInfo()
        {
            return ViewComponent("CrachasInfo");
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllCrachas(DataSourceLoadOptions loadOptions)
        {
            return await _crachaAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetCrachaForEditOutput getCrachaForEditOutput;

            if (id.HasValue)
            {
                getCrachaForEditOutput = await _crachaAppService.GetCrachaForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getCrachaForEditOutput = new GetCrachaForEditOutput
                {
                    Cracha = new CreateOrEditCrachaDto()
                };
            }

            var viewModel = new CreateOrEditCrachaViewModel()
            {
                Cracha = getCrachaForEditOutput.Cracha
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
