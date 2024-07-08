using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Souccar.Hcpc.Materials.Services;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services;
using System.Threading.Tasks;

namespace Souccar.Jobs
{
    public class CheckMaterialExpiryBackgroundWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IWarehouseMaterialAppService _warehouseMaterialAppService;

        public CheckMaterialExpiryBackgroundWorker(AbpAsyncTimer timer, IWarehouseMaterialAppService warehouseMaterialAppService)
            : base(timer)
        {
            Timer.Period = 20000; //5 seconds (good for tests, but normally will be more)
            _warehouseMaterialAppService = warehouseMaterialAppService;


            //Timer.Period = 86400000; // Day
        }
        [UnitOfWork]
        protected override async Task DoWorkAsync()
        {
           //await _warehouseMaterialAppService.SendMaterialExpiryNotifications();
        }
    }
}
