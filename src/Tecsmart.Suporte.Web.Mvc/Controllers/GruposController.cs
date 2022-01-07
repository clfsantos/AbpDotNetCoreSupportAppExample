using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Produtos;
using Tecsmart.Suporte.Produtos.Dto;
using Tecsmart.Suporte.Web.Models.Produtos;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class GruposController : SuporteControllerBase
    {
        private readonly IGrupoAppService _grupoAppService;
        public GruposController(IGrupoAppService grupoAppService)
        {
            _grupoAppService = grupoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllGrupos(DataSourceLoadOptions loadOptions)
        {
            return await _grupoAppService.GetAllGrupos(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetGrupoForEditOutput getGrupoForEditOutput;

            if (id.HasValue)
            {
                getGrupoForEditOutput = await _grupoAppService.GetGrupoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getGrupoForEditOutput = new GetGrupoForEditOutput
                {
                    Grupo = new CreateOrEditGrupoDto()
                };
            }

            var viewModel = new CreateOrEditGrupoViewModel()
            {
                Grupo = getGrupoForEditOutput.Grupo,
                Produtos = getGrupoForEditOutput.Produtos
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
