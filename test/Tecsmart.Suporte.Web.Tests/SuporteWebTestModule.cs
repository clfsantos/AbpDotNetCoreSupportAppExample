using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Tecsmart.Suporte.EntityFrameworkCore;
using Tecsmart.Suporte.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Tecsmart.Suporte.Web.Tests
{
    [DependsOn(
        typeof(SuporteWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SuporteWebTestModule : AbpModule
    {
        public SuporteWebTestModule(SuporteEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SuporteWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SuporteWebMvcModule).Assembly);
        }
    }
}