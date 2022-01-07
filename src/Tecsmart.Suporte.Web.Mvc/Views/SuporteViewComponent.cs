using Abp.AspNetCore.Mvc.ViewComponents;

namespace Tecsmart.Suporte.Web.Views
{
    public abstract class SuporteViewComponent : AbpViewComponent
    {
        protected SuporteViewComponent()
        {
            LocalizationSourceName = SuporteConsts.LocalizationSourceName;
        }
    }
}
