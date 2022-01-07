using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Tecsmart.Suporte.Controllers
{
    public abstract class SuporteControllerBase: AbpController
    {
        protected SuporteControllerBase()
        {
            LocalizationSourceName = SuporteConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
