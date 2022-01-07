using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.GridStates;
using Tecsmart.Suporte.GridStates.Dto;
using Tecsmart.Suporte.Web.Models.GridStates;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class GridStatesController : SuporteControllerBase
    {
        private readonly IGridStateAppService _gridStateAppService;
        public GridStatesController(IGridStateAppService gridStateAppService)
        {
            _gridStateAppService = gridStateAppService;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllStates(DataSourceLoadOptions loadOptions, string tela)
        {
            return await _gridStateAppService.GetAllForLoadResult(loadOptions, tela);
        }

        public async Task<PartialViewResult> CreateOrEditModal(int? id, string tela, string state)
        {
            GetGridStateForEditOutput getGridStateForEditOutput;

            if (id.HasValue)
            {
                getGridStateForEditOutput = await _gridStateAppService.GetGridStateForEdit(new EntityDto<int> { Id = (int)id });
            }
            else
            {
                getGridStateForEditOutput = new GetGridStateForEditOutput
                {
                    GridState = new CreateOrEditGridStateDto()
                };
            }

            var viewModel = new CreateOrEditGridStateViewModel()
            {
                GridState = getGridStateForEditOutput.GridState
            };

            viewModel.GridState.Tela = tela;
            viewModel.GridState.State = state;

            return PartialView("_CreateOrEditModal", viewModel);
        }

        public PartialViewResult ViewGridStatesFiltersModal(string tela, string state)
        {
            GetGridStateForEditOutput getGridStateForEditOutput;

            getGridStateForEditOutput = new GetGridStateForEditOutput
            {
                GridState = new CreateOrEditGridStateDto()
            };
            
            var viewModel = new CreateOrEditGridStateViewModel()
            {
                GridState = getGridStateForEditOutput.GridState
            };

            viewModel.GridState.Tela = tela;
            viewModel.GridState.State = state;

            return PartialView("_GridStatesFiltersView", viewModel);
        }

    }
}
