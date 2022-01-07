using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Clientes;
using Tecsmart.Suporte.Clientes.Dto;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Web.Models.Clientes;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ClientesController : SuporteControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllClientes(DataSourceLoadOptions loadOptions)
        {
            return await _clienteAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetContratosCliente(DataSourceLoadOptions loadOptions)
        {
            return await _clienteAppService.GetContratosCliente(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetClienteForEditOutput getClienteForEditOutput;

            if (id.HasValue)
            {
                getClienteForEditOutput = await _clienteAppService.GetClienteForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getClienteForEditOutput = new GetClienteForEditOutput
                {
                    Cliente = new CreateOrEditClienteDto()
                };
            }

            var viewModel = new CreateOrEditClienteViewModel()
            {
                Cliente = getClienteForEditOutput.Cliente
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
