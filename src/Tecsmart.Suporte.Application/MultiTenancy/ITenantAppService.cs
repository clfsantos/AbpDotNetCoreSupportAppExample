using Abp.Application.Services;
using Tecsmart.Suporte.MultiTenancy.Dto;

namespace Tecsmart.Suporte.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

