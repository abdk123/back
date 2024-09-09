using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Souccar.Authorization;
using Souccar.Authorization.Users;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Workers
{
    public class CheckRemainingDaysForPaidWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly ISaleInvoiceDomainService _saleInvoiceDomainService;
        private readonly UserManager _userManager;

        public CheckRemainingDaysForPaidWorker(AbpAsyncTimer timer, ISaleInvoiceDomainService saleInvoiceDomainService, UserManager userManager)
            : base(timer)
        {
            Timer.Period = 15000;
            _saleInvoiceDomainService = saleInvoiceDomainService;
            _userManager = userManager;
        }

        [UnitOfWork]
        protected override async Task DoWorkAsync()
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant, AbpDataFilters.MustHaveTenant))
            {
                var users = _userManager.Users.ToList();
                var identifiers = users.Select(user =>
                {
                    return user.ToUserIdentifier();
                }).ToArray();
                await _saleInvoiceDomainService.CheckSaleInvoiceAsync(identifiers);
            }
        }
    }
}
