using Abp.Notifications;
using Souccar.Authorization.Users;
using System;
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
    }
}