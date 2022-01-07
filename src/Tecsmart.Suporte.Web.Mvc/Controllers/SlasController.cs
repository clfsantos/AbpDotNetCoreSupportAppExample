using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Slas;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class SlasController : SuporteControllerBase
    {
        private readonly ISlaAppService _slaAppService;
        public SlasController(ISlaAppService slaAppService)
        {
            _slaAppService = slaAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllSlas(DataSourceLoadOptions loadOptions)
        {
            return await _slaAppService.GetAllForLoadResult(loadOptions);
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
