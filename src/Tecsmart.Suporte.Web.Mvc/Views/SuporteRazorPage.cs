using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Tecsmart.Suporte.Web.Views
{
    public abstract class SuporteRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected SuporteRazorPage()
        {
            LocalizationSourceName = SuporteConsts.LocalizationSourceName;
        }
    }
}
