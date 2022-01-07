using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Eventos;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class EventosController : SuporteControllerBase
    {
        private readonly IEventoAppService _eventoAppService;
        public EventosController(IEventoAppService eventoAppService)
        {
            _eventoAppService = eventoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllEventos(DataSourceLoadOptions loadOptions)
        {
            return await _eventoAppService.GetAllForLoadResult(loadOptions);
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
