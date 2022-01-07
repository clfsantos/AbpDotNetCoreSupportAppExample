using System.Collections.Generic;

namespace Tecsmart.Suporte.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
