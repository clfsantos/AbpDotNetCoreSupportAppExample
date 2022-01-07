using System.Collections.Generic;
using System.Linq;
using Tecsmart.Suporte.Roles.Dto;
using Tecsmart.Suporte.Users.Dto;

namespace Tecsmart.Suporte.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
