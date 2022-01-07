using Abp.Authorization;
using Tecsmart.Suporte.Authorization.Roles;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
