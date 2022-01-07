using Microsoft.AspNetCore.Mvc;
using Tecsmart.Suporte.Crachas;

namespace Tecsmart.Suporte.Web.Views.Shared.Components.CrachasInfo
{
    public class CrachasInfoViewComponent : SuporteViewComponent
    {
        private readonly ICrachaAppService _crachaAppService;

        public CrachasInfoViewComponent(ICrachaAppService crachaAppService)
        {
            _crachaAppService = crachaAppService;
        }

        public IViewComponentResult Invoke()
        {
            var crachasInfo = new CrachasInfoViewModel()
            {
                CrachaInfo = _crachaAppService.GetInfoCrachas()
            };

            return View(crachasInfo);
        }
    }
}
