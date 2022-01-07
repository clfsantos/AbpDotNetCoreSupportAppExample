using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.FilaAtendimentos;
using Tecsmart.Suporte.FilaAtendimentos.Dto;
using Tecsmart.Suporte.Web.Models.FilaAtendimentos;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class FilaAtendimentosController : SuporteControllerBase
    {
        private readonly IFilaAtendimentoAppService _filaAtendimentoAppService;
        private readonly IFilaRetornoAppService _filaRetornoAppService;
        public FilaAtendimentosController(IFilaAtendimentoAppService filaAtendimentoAppService, IFilaRetornoAppService filaRetornoAppService)
        {
            _filaAtendimentoAppService = filaAtendimentoAppService;
            _filaRetornoAppService = filaRetornoAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        //public IActionResult ReloadFluxo()
        //{
        //    return ViewComponent("FluxoAtendimento");
        //}

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllFila(DataSourceLoadOptions loadOptions)
        {
            return await _filaAtendimentoAppService.GetAllForLoadResult(loadOptions);
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllRetornos(DataSourceLoadOptions loadOptions, int filaAtendimentoId)
        {
            return await _filaRetornoAppService.GetAllForLoadResult(loadOptions, filaAtendimentoId);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id)
        {
            GetFilaAtendimentoForEditOutput getFilaAtendimentoForEditOutput;

            if (id.HasValue)
            {
                getFilaAtendimentoForEditOutput = await _filaAtendimentoAppService.GetFilaAtendimentoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getFilaAtendimentoForEditOutput = new GetFilaAtendimentoForEditOutput
                {
                    FilaAtendimento = new CreateOrEditFilaAtendimentoDto()
                };
            }

            var viewModel = new CreateOrEditFilaAtendimentoViewModel()
            {
                FilaAtendimento = getFilaAtendimentoForEditOutput.FilaAtendimento
            };

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public async Task<PartialViewResult> CreateOrEditModalRetorno(int? id, int filaAtendimentoId)
        {
            GetFilaRetornoForEditOutput getFilaRetornoForEditOutput;

            if (id.HasValue)
            {
                getFilaRetornoForEditOutput = await _filaRetornoAppService.GetFilaRetornoForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getFilaRetornoForEditOutput = new GetFilaRetornoForEditOutput
                {
                    FilaRetorno = new CreateOrEditFilaRetornoDto()
                };
            }

            var viewModel = new CreateOrEditFilaRetornoViewModel()
            {
                FilaRetorno = getFilaRetornoForEditOutput.FilaRetorno
            };

            viewModel.FilaRetorno.FilaAtendimentoId = filaAtendimentoId;

            return PartialView("_CreateOrEditModalRetorno", viewModel);
        }

    }
}
