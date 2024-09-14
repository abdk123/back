using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Threading.BackgroundWorkers;
using Abp.Threading.Timers;
using Souccar.Authorization;
using Souccar.Authorization.Users;
using Souccar.Notification;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.SaleManagement.PurchaseOrders.SaleInvoices.Workers
{
    public class CheckRemainingDaysForPaidWorker : AsyncPeriodicBackgroundWorkerBase, ISingletonDependency
    {
        private readonly ISaleInvoiceDomainService _saleInvoiceDomainService;
        private readonly UserManager _userManager;
        private readonly IAppNotifier _appNotifier;

        public CheckRemainingDaysForPaidWorker(AbpAsyncTimer timer, ISaleInvoiceDomainService saleInvoiceDomainService, UserManager userManager, IAppNotifier appNotifier)
            : base(timer)
        {
            Timer.Period = 15000;
            _saleInvoiceDomainService = saleInvoiceDomainService;
            _userManager = userManager;
            _appNotifier = appNotifier;
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
                var invoices = await _saleInvoiceDomainService.CheckSaleInvoiceAsync();
                foreach (var saleInvoice in invoices)
                {
                    var title = "فاتورة مبيعات يجب دفعها من قبل الزبون " + saleInvoice.Customer.FullName;
                    var dic = new Dictionary<string, object>()
                        {
                            {"Id",saleInvoice.Id },
                            {"TotalQuantity",saleInvoice.InvoiceTotalQuantity },
                            {"DateForPaid",saleInvoice.DateForPaid },
                            {"Currency",saleInvoice.SaleCurrency },
                        };
                    await _appNotifier.SendSaleInvoiceNotify(title, dic, identifiers);
                }
            }
        }
    }
}
