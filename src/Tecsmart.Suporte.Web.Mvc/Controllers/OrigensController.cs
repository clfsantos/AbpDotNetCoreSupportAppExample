using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Origens;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class OrigensController : SuporteControllerBase
    {
        private readonly IOrigemAppService _origemAppService;
        public OrigensController(IOrigemAppService origemAppService)
        {
            _origemAppService = origemAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllOrigens(DataSourceLoadOptions loadOptions)
        {
            return await _origemAppService.GetAllForLoadResult(loadOptions);
        }

        //public async Task<PartialViewResult> CreateOrEditModal(int? id)
        //{
        //    GetClienteForEditOutput getClienteForEditOutput;

        //    if (id.HasValue)
        //    {
        //        getClienteForEditOutput = await _clienteAppService.GetClienteForEdit(new EntityDto<int> { Id = (int)id });
        //    }
        //    else
        //    {
        //        getClienteForEditOutput = new GetClienteForEditOutput
        //        {
        //            Cliente = new CreateOrEditClienteDto()
        //        };
        //    }

        //    var viewModel = new CreateOrEditClienteViewModel()
        //    {
        //        Cliente = getClienteForEditOutput.Cliente
        //    };

        //    return PartialView("_CreateOrEditModal", viewModel);
        //}

    }
}
