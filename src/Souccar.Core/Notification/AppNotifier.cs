using Abp.Domain.Uow;
using Abp.Notifications;
using System;
using System.Collections.Generic;
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

        [UnitOfWork]
        public async Task SendSaleInvoiceNotify(string title, Dictionary<string, object> dic, Abp.UserIdentifier[] identifiers)
        {
            try
            {
                var body = new MessageNotificationData(title);

                body.Properties = dic;
                await _notificationPublisher.PublishAsync(
                    title,
                    body,
                    severity: NotificationSeverity.Warn,
                    userIds: identifiers
                    );
            }
            catch (Exception ex)
            {

            }
        }
    }
}