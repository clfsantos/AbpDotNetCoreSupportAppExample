using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tecsmart.Suporte.Chamados;

namespace Tecsmart.Suporte.Web.Views.Shared.Components.FluxoAtendimento
{
    public class FluxoAtendimentoViewComponent : SuporteViewComponent
    {
        private readonly IChamadoAppService _chamadoAppService;

        public FluxoAtendimentoViewComponent(IChamadoAppService chamadoAppService)
        {
            _chamadoAppService = chamadoAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lista = new FluxoAtendimentoViewModel()
            {
                PrioridadeFluxo = await _chamadoAppService.ObterListaPrioridadeFluxo()
            };

            return View(lista);
        }
    }
}
