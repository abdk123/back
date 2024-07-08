using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Souccar.Authorization;

namespace Souccar
{
    [DependsOn(
        typeof(SouccarCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class SouccarApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<SouccarAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(SouccarApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
