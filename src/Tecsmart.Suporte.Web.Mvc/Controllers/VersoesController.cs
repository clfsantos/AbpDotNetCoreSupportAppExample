using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Releases;
using Tecsmart.Suporte.Releases.Dto;
using Tecsmart.Suporte.Web.Models.Releases;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class VersoesController : SuporteControllerBase
    {
        private readonly IReleaseAppService _releaseAppService;
        public VersoesController(IReleaseAppService releaseAppService)
        {
            _releaseAppService = releaseAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllReleases(DataSourceLoadOptions loadOptions)
        {
            return await _releaseAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetReleaseForEditOutput getReleaseForEditOutput;

            if (id.HasValue)
            {
                getReleaseForEditOutput = await _releaseAppService.GetReleaseForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getReleaseForEditOutput = new GetReleaseForEditOutput
                {
                    Release = new CreateOrEditReleaseDto()
                };
            }

            var viewModel = new CreateOrEditReleaseViewModel()
            {
                Release = getReleaseForEditOutput.Release
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
