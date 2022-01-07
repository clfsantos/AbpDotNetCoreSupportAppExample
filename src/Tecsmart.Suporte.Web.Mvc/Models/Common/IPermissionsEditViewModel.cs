using System.Collections.Generic;
using Tecsmart.Suporte.Roles.Dto;

namespace Tecsmart.Suporte.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}