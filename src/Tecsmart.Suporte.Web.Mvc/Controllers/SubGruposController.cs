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
    public class SubGruposController : SuporteControllerBase
    {
        private readonly ISubGrupoAppService _subGrupoAppService;
        public SubGruposController(ISubGrupoAppService subGrupoAppService)
        {
            _subGrupoAppService = subGrupoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllSubGrupos(DataSourceLoadOptions loadOptions)
        {
            return await _subGrupoAppService.GetAllSubGrupos(loadOptions);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetSubGrupoForEditOutput getSubGrupoForEditOutput;

            if (id.HasValue)
            {
                getSubGrupoForEditOutput = await _subGrupoAppService.GetSubGrupoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getSubGrupoForEditOutput = new GetSubGrupoForEditOutput
                {
                    SubGrupo = new CreateOrEditSubGrupoDto()
                };
            }

            var viewModel = new CreateOrEditSubGrupoViewModel()
            {
                SubGrupo = getSubGrupoForEditOutput.SubGrupo,
                Grupos = getSubGrupoForEditOutput.Grupos
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

    }
}
