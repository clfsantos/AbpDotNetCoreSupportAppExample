using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Tecsmart.Suporte.Authorization;

namespace Tecsmart.Suporte
{
    [DependsOn(
        typeof(SuporteCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SuporteApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SuporteAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SuporteApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
