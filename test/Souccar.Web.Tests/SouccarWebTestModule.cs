using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Souccar.EntityFrameworkCore;
using Souccar.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Souccar.Web.Tests
{
    [DependsOn(
        typeof(SouccarWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class SouccarWebTestModule : AbpModule
    {
        public SouccarWebTestModule(SouccarEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SouccarWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(SouccarWebMvcModule).Assembly);
        }
    }
}