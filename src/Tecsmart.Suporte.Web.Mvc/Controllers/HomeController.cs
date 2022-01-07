using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using Tecsmart.Suporte.Controllers;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : SuporteControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
