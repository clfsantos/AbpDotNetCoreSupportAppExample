using Abp.MultiTenancy;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
