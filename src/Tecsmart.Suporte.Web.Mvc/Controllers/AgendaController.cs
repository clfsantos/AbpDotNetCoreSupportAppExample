using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados;
using Tecsmart.Suporte.Controllers;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AgendaController : SuporteControllerBase
    {
        private readonly ITarefaAppService _tarefaAppService;
        public AgendaController(ITarefaAppService tarefaAppService)
        {
            _tarefaAppService = tarefaAppService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllTarefas(DataSourceLoadOptions loadOptions)
        {
            return await _tarefaAppService.GetAllForAgendaLoadResult(loadOptions);
        }

    }
}
