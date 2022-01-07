using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Modelos;
using Tecsmart.Suporte.Modelos.Dto;
using Tecsmart.Suporte.Web.Models.Equipamentos.Modelos;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ModelosController : SuporteControllerBase
    {
        private readonly IModeloAppService _modeloAppService;
        public ModelosController(IModeloAppService modeloAppService)
        {
            _modeloAppService = modeloAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllModelos(DataSourceLoadOptions loadOptions)
        {
            return await _modeloAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetModeloForEditOutput getModeloForEditOutput;

            if (id.HasValue)
            {
                getModeloForEditOutput = await _modeloAppService.GetModeloForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getModeloForEditOutput = new GetModeloForEditOutput
                {
                    Modelo = new CreateOrEditModeloDto()
                };
            }

            var viewModel = new CreateOrEditModeloViewModel()
            {
                Modelo = getModeloForEditOutput.Modelo
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
