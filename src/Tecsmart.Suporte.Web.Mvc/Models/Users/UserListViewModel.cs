using System.Collections.Generic;
using Tecsmart.Suporte.Roles.Dto;

namespace Tecsmart.Suporte.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
