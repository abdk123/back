using Abp.Authorization;
using Abp.Localization;
using Abp.Notifications;
using Souccar.Authorization;

namespace Souccar.Notification
{
    public class AppNotificationProvider : NotificationProvider
    {
        public override void SetNotifications(INotificationDefinitionContext context)
        {
            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationNames.SaleInvoiceMustPaid,
                    displayName: L("SendSaleInvoiceNotify")
                    //permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Administration_Users)
                    )
                );

            context.Manager.Add(
                new NotificationDefinition(
                    AppNotificationNames.ReceiveMaterials,
                    displayName: L("ReceiveMaterials")
                    //permissionDependency: new SimplePermissionDependency(PermissionNames.Setting_Notifications_Receive_Material)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SouccarConsts.LocalizationSourceName);
        }
    }
}
