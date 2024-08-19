using Abp.Domain.Uow;
using Abp.Notifications;
using Abp.Threading;
using Souccar.Authorization;
using Souccar.Authorization.Users;
using Souccar.SaleManagement.PurchaseOrders.SaleInvoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Notification
{
    public class AppNotifier : SouccarDomainServiceBase, IAppNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;

        public AppNotifier(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }        

        public async Task SendMaterialExpiryDate(User user, string name, DateTime date)
        {
            var param = new string[2] {name, date.ToString("dd/MM/yyyy") };
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.MaterialExpirationWarning,
                new MessageNotificationData(L("The{0}MaterialWillExpireOn{1}", param)),
                severity: NotificationSeverity.Warn,
                userIds: new[] { user.ToUserIdentifier() }
                );
        }

        public async Task SendCreateOutputRequst(User user, string title)
        {
            var param = new string[1] {title};

            await _notificationPublisher.PublishAsync(
                AppNotificationNames.AddOutputRequest,
                new MessageNotificationData(L("{0}OutputRequestAdded", param)),
                severity: NotificationSeverity.Warn,
                userIds: new[] { user.ToUserIdentifier() }
                );
        }
        public void SendSaleInvoiceNotify(SaleInvoice saleInvoice)
        {
            try
            {
                var title = "فاتورة مبيعات يجب دفعها من قبل الزبون " + saleInvoice.Customer.FullName;
                var body = new MessageNotificationData(title);
                var dic = new Dictionary<string, object>()
            {
                {"Id",saleInvoice.Id },
                {"TotalQuantity",saleInvoice.InvoiceTotalQuantity },
                {"DateForPaid",saleInvoice.DateForPaid },
                {"Currency",saleInvoice.SaleCurrency },
            };
                body.Properties = dic;
                AsyncHelper.RunSync(()=>_notificationPublisher.PublishAsync(
                    title,
                    body,
                    severity: NotificationSeverity.Warn,
                    userIds: new[] { UserIdentifierHelper.Identifier }
                    ));
            }
            catch(Exception ex)
            {

            }
        }
    }
}