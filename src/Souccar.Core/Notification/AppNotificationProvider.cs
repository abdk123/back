﻿using Abp.Localization;
using Abp.Notifications;

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

            //context.Manager.Add(
            //    new NotificationDefinition(
            //        AppNotificationNames.NewTenantRegistered,
            //        displayName: L("NewTenantRegisteredNotificationDefinition"),
            //        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
            //        )
            //    );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SouccarConsts.LocalizationSourceName);
        }
    }
}
