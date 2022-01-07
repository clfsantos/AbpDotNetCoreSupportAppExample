using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Tecsmart.Suporte.Configuration.Dto;

namespace Tecsmart.Suporte.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SuporteAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
