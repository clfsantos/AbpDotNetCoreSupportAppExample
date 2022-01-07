using Abp.AutoMapper;
using Tecsmart.Suporte.Roles.Dto;
using Tecsmart.Suporte.Web.Models.Common;

namespace Tecsmart.Suporte.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
