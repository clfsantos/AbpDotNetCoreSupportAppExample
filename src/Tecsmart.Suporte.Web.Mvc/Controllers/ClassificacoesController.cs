using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Classificacoes;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ClassificacoesController : SuporteControllerBase
    {
        private readonly IClassificacaoAppService _classificacaoAppService;
        public ClassificacoesController(IClassificacaoAppService classificacaoAppService)
        {
            _classificacaoAppService = classificacaoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllClassificacoes(DataSourceLoadOptions loadOptions)
        {
            return await _classificacaoAppService.GetAllForLoadResult(loadOptions);
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
