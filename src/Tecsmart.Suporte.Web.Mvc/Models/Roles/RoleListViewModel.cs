using System.Collections.Generic;
using Tecsmart.Suporte.Roles.Dto;

namespace Tecsmart.Suporte.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
