using Abp.Notifications;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Notification.Dto
{
    public class NotificationSubscriptionDto
    {
        [Required]
        [MaxLength(NotificationInfo.MaxNotificationNameLength)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }
    }
}
