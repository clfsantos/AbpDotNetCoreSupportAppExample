using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Equipamentos;
using Tecsmart.Suporte.Equipamentos.Dto;
using Tecsmart.Suporte.Web.Models.Equipamentos;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class EquipamentosController : SuporteControllerBase
    {
        private readonly IEquipamentoAppService _equipamentoAppService;
        public EquipamentosController(IEquipamentoAppService equipamentoAppService)
        {
            _equipamentoAppService = equipamentoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllEquipamentos(DataSourceLoadOptions loadOptions)
        {
            return await _equipamentoAppService.GetAllForLoadResult(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetEquipamentoForEditOutput getEquipamentoForEditOutput;

            if (id.HasValue)
            {
                getEquipamentoForEditOutput = await _equipamentoAppService.GetEquipamentoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getEquipamentoForEditOutput = new GetEquipamentoForEditOutput
                {
                    Equipamento = new CreateOrEditEquipamentoDto()
                };
            }

            var viewModel = new CreateOrEditEquipamentoViewModel()
            {
                Equipamento = getEquipamentoForEditOutput.Equipamento
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
