using Abp.AutoMapper;
using Abp.Localization.Sources;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Threading.BackgroundWorkers;
using Souccar.Authorization;
using Souccar.Notification;
using Souccar.SaleManagement.SaleInvoices.Workers;

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
            Configuration.Notifications.Providers.Add<AppNotificationProvider>();

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

        public override void PostInitialize()
        {
            var workManager = IocManager.Resolve<IBackgroundWorkerManager>();
            workManager.Add(IocManager.Resolve<CheckRemainingDaysForPaidWorker>());

            base.PostInitialize();
        }
    }
}
