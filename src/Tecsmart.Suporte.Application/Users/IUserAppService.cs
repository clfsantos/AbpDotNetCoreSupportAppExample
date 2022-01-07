using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Tecsmart.Suporte.Roles.Dto;
using Tecsmart.Suporte.Users.Dto;

namespace Tecsmart.Suporte.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
        Task<bool> ChangeFoto(ChangeFotoDto input);

        Task<LoadResult> GetAllForLoadResult(DataSourceLoadOptions loadOptions);
    }
}
