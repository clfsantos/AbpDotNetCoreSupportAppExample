using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Tecsmart.Suporte.Configuration;

namespace Tecsmart.Suporte.Web.Host.Startup
{
    [DependsOn(
       typeof(SuporteWebCoreModule))]
    public class SuporteWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public SuporteWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SuporteWebHostModule).GetAssembly());
        }
    }
}
