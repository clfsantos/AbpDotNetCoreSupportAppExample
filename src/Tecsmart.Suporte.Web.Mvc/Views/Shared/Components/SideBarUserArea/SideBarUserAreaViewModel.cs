using Tecsmart.Suporte.Sessions.Dto;

namespace Tecsmart.Suporte.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewModel
    {
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }

        public bool IsMultiTenancyEnabled { get; set; }

        public string GetShownLoginName()
        {
            var userName = LoginInformations.User.UserName;

            if (!IsMultiTenancyEnabled)
            {
                return userName;
            }

            return LoginInformations.Tenant == null
                ? ".\\" + userName
                : LoginInformations.Tenant.TenancyName + "\\" + userName;
        }

        public string GetUserName()
        {
            return string.Concat(LoginInformations.User.Name, ' ', LoginInformations.User.Surname);
        }

        public string GetCaminhoFoto()
        {
            return LoginInformations.User.CaminhoFoto;
        }
    }
}
