using System.Threading.Tasks;
using Tecsmart.Suporte.Configuration.Dto;

namespace Tecsmart.Suporte.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
