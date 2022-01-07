using Abp.AutoMapper;
using Tecsmart.Suporte.Authentication.External;

namespace Tecsmart.Suporte.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
