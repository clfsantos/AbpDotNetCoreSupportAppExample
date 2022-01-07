using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados;

namespace Tecsmart.Suporte.Web.Views.Shared.Components.AssistenciasAbertas
{
    public class AssistenciasAbertasViewComponent : SuporteViewComponent
    {
        private readonly IAssistenciaAppService _assistenciaAppService;

        public AssistenciasAbertasViewComponent(IAssistenciaAppService assistenciaAppService)
        {
            _assistenciaAppService = assistenciaAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var assistencias = new AssistenciasAbertasViewModel()
            {
                Assistencias = await _assistenciaAppService.GetAssistenciasAbertas()
            };

            return View(assistencias);
        }
    }
}
