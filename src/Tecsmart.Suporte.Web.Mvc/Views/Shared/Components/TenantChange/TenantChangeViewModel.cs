using Abp.AutoMapper;
using Tecsmart.Suporte.Sessions.Dto;

namespace Tecsmart.Suporte.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
