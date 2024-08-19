using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Souccar.Authorization;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Workers
{
    public class CheckRemainingDaysForPaidWorker : PeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly ISaleInvoiceDomainService _saleInvoiceDomainService;
        public CheckRemainingDaysForPaidWorker(AbpTimer timer, ISaleInvoiceDomainService saleInvoiceDomainService)
            : base(timer)
        {
            Timer.Period = 15000;
            _saleInvoiceDomainService = saleInvoiceDomainService;
        }

        protected override void DoWork()
        {
            if (UserIdentifierHelper.Identifier != null)
            {
                _saleInvoiceDomainService.CheckSaleInvoiceAsync();
            }
        }
    }
}
