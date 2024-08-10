using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Souccar.Authorization
{
    public class SouccarAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Setting_Tenants, L("Tenants"));
            context.CreatePermission(PermissionNames.Setting_Users_Activation, L("UsersActivation"));

            //Users
            context.CreatePermission(PermissionNames.Security_Users, L("Users"));
            context.CreatePermission(PermissionNames.Security_Users_Create, L("CreateNewUser"));
            context.CreatePermission(PermissionNames.Security_Users_Edit, L("EditUser"));
            context.CreatePermission(PermissionNames.Security_Users_Delete, L("DeleteUser"));
            context.CreatePermission(PermissionNames.Security_Users_ResetPassword, L("ResetPassword"));
            context.CreatePermission(PermissionNames.Security_Users_ChangePermissions, L("ChangePermissions"));

            //Roles
            context.CreatePermission(PermissionNames.Security_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Security_Roles_Create, L("CreateNewRole"));
            context.CreatePermission(PermissionNames.Security_Roles_Edit, L("EditRole"));
            context.CreatePermission(PermissionNames.Security_Roles_Delete, L("DeleteRole"));


            //Stocks
            context.CreatePermission(PermissionNames.Setting_Stocks, L("Stock"));
            context.CreatePermission(PermissionNames.Setting_Stocks_Create, L("CreateNewStock"));
            context.CreatePermission(PermissionNames.Setting_Stocks_Update, L("EditStock"));
            context.CreatePermission(PermissionNames.Setting_Stocks_Delete, L("DeleteStock"));

            //Sizes
            context.CreatePermission(PermissionNames.Setting_Sizes, L("Size"));
            context.CreatePermission(PermissionNames.Setting_Sizes_Create, L("CreateNewSize"));
            context.CreatePermission(PermissionNames.Setting_Sizes_Update, L("EditSize"));
            context.CreatePermission(PermissionNames.Setting_Sizes_Delete, L("DeleteSize"));

            //Units
            context.CreatePermission(PermissionNames.Setting_Units, L("Unit"));
            context.CreatePermission(PermissionNames.Setting_Units_Create, L("CreateNewUnit"));
            context.CreatePermission(PermissionNames.Setting_Units_Update, L("EditUnit"));
            context.CreatePermission(PermissionNames.Setting_Units_Delete, L("DeleteUnit"));

            //UnitSizes
            context.CreatePermission(PermissionNames.Setting_UnitSizes, L("UnitSize"));
            context.CreatePermission(PermissionNames.Setting_UnitSizes_Create, L("CreateNewUnitSize"));
            context.CreatePermission(PermissionNames.Setting_UnitSizes_Update, L("EditUnitSize"));
            context.CreatePermission(PermissionNames.Setting_UnitSizes_Delete, L("DeleteUnitSize"));

            //Stores
            context.CreatePermission(PermissionNames.Setting_Stores, L("Store"));
            context.CreatePermission(PermissionNames.Setting_Stores_Create, L("CreateNewStore"));
            context.CreatePermission(PermissionNames.Setting_Stores_Update, L("EditStore"));
            context.CreatePermission(PermissionNames.Setting_Stores_Delete, L("DeleteStore"));

            //Materials
            context.CreatePermission(PermissionNames.Setting_Materials, L("Material"));
            context.CreatePermission(PermissionNames.Setting_Materials_Create, L("CreateNewMaterial"));
            context.CreatePermission(PermissionNames.Setting_Materials_Update, L("EditMaterial"));
            context.CreatePermission(PermissionNames.Setting_Materials_Delete, L("DeleteMaterial"));

            //Customers
            context.CreatePermission(PermissionNames.Setting_Customers, L("Customer"));
            context.CreatePermission(PermissionNames.Setting_Customers_Create, L("CreateNewCustomer"));
            context.CreatePermission(PermissionNames.Setting_Customers_Update, L("EditCustomer"));
            context.CreatePermission(PermissionNames.Setting_Customers_Delete, L("DeleteCustomer"));

            //Companies
            context.CreatePermission(PermissionNames.Setting_Companies, L("Company"));
            context.CreatePermission(PermissionNames.Setting_Companies_Create, L("CreateNewCompany"));
            context.CreatePermission(PermissionNames.Setting_Companies_Update, L("EditCompany"));
            context.CreatePermission(PermissionNames.Setting_Companies_Delete, L("DeleteCompany"));

            //Categories
            context.CreatePermission(PermissionNames.Setting_Categories, L("Category"));
            context.CreatePermission(PermissionNames.Setting_Categories_Create, L("CreateNewCategory"));
            context.CreatePermission(PermissionNames.Setting_Categories_Update, L("EditCategory"));
            context.CreatePermission(PermissionNames.Setting_Categories_Delete, L("DeleteCategory"));



            //CustomerVouchers
            context.CreatePermission(PermissionNames.Setting_CustomerVouchers, L("CustomerVoucher"));
            context.CreatePermission(PermissionNames.Setting_CustomerVouchers_Create, L("CreateNewCustomerVoucher"));
            context.CreatePermission(PermissionNames.Setting_CustomerVouchers_Update, L("EditCustomerVoucher"));
            context.CreatePermission(PermissionNames.Setting_CustomerVouchers_Delete, L("DeleteCustomerVoucher"));

            //ClearanceCompanyVouchers
            context.CreatePermission(PermissionNames.Setting_ClearanceCompanyVouchers, L("ClearanceCompanyVoucher"));
            context.CreatePermission(PermissionNames.Setting_ClearanceCompanyVouchers_Create, L("CreateNewClearanceCompanyVoucher"));
            context.CreatePermission(PermissionNames.Setting_ClearanceCompanyVouchers_Update, L("EditClearanceCompanyVoucher"));
            context.CreatePermission(PermissionNames.Setting_ClearanceCompanyVouchers_Delete, L("DeleteClearanceCompanyVoucher"));


            //TransportCompanyVouchers
            context.CreatePermission(PermissionNames.Setting_TransportCompanyVouchers, L("TransportCompanyVoucher"));
            context.CreatePermission(PermissionNames.Setting_TransportCompanyVouchers_Create, L("CreateNewTransportCompanyVoucher"));
            context.CreatePermission(PermissionNames.Setting_TransportCompanyVouchers_Update, L("EditTransportCompanyVoucher"));
            context.CreatePermission(PermissionNames.Setting_TransportCompanyVouchers_Delete, L("DeleteTransportCompanyVoucher"));


            //Receivings
            context.CreatePermission(PermissionNames.Setting_Receivings, L("Receiving"));
            context.CreatePermission(PermissionNames.Setting_Receivings_Create, L("CreateNewReceiving"));
            context.CreatePermission(PermissionNames.Setting_Receivings_Update, L("EditReceiving"));
            context.CreatePermission(PermissionNames.Setting_Receivings_Delete, L("DeleteReceiving"));

            //ReceivingItems
            context.CreatePermission(PermissionNames.Setting_ReceivingItems, L("ReceivingItem"));
            context.CreatePermission(PermissionNames.Setting_ReceivingItems_Create, L("CreateNewReceivingItem"));
            context.CreatePermission(PermissionNames.Setting_ReceivingItems_Update, L("EditReceivingItem"));
            context.CreatePermission(PermissionNames.Setting_ReceivingItems_Delete, L("DeleteReceivingItem"));

            //Offers
            context.CreatePermission(PermissionNames.Setting_Offers, L("Offer"));
            context.CreatePermission(PermissionNames.Setting_Offers_Create, L("CreateNewOffer"));
            context.CreatePermission(PermissionNames.Setting_Offers_Update, L("EditOffer"));
            context.CreatePermission(PermissionNames.Setting_Offers_Delete, L("DeleteOffer"));

            //OfferItems
            context.CreatePermission(PermissionNames.Setting_OfferItems, L("OfferItem"));
            context.CreatePermission(PermissionNames.Setting_OfferItems_Create, L("CreateNewOfferItem"));
            context.CreatePermission(PermissionNames.Setting_OfferItems_Update, L("EditOfferItem"));
            context.CreatePermission(PermissionNames.Setting_OfferItems_Delete, L("DeleteOfferItem"));

            //Invoices
            context.CreatePermission(PermissionNames.Setting_Invoices, L("Invoice"));
            context.CreatePermission(PermissionNames.Setting_Invoices_Create, L("CreateNewInvoice"));
            context.CreatePermission(PermissionNames.Setting_Invoices_Update, L("EditInvoice"));
            context.CreatePermission(PermissionNames.Setting_Invoices_Delete, L("DeleteInvoice"));

            //InvoiceItems
            context.CreatePermission(PermissionNames.Setting_InvoiceItems, L("InvoiceItem"));
            context.CreatePermission(PermissionNames.Setting_InvoiceItems_Create, L("CreateNewInvoiceItem"));
            context.CreatePermission(PermissionNames.Setting_InvoiceItems_Update, L("EditInvoiceItem"));
            context.CreatePermission(PermissionNames.Setting_InvoiceItems_Delete, L("DeleteInvoiceItem"));

            //Deliveries
            context.CreatePermission(PermissionNames.Setting_Deliveries, L("Delivery"));
            context.CreatePermission(PermissionNames.Setting_Deliveries_Create, L("CreateNewDelivery"));
            context.CreatePermission(PermissionNames.Setting_Deliveries_Update, L("EditDelivery"));
            context.CreatePermission(PermissionNames.Setting_Deliveries_Delete, L("DeleteDelivery"));

            //DeliveryItems
            context.CreatePermission(PermissionNames.Setting_DeliveryItems, L("DeliveryItem"));
            context.CreatePermission(PermissionNames.Setting_DeliveryItems_Create, L("CreateNewDeliveryItem"));
            context.CreatePermission(PermissionNames.Setting_DeliveryItems_Update, L("EditDeliveryItem"));
            context.CreatePermission(PermissionNames.Setting_DeliveryItems_Delete, L("DeleteDeliveryItem"));

            //Employees
            context.CreatePermission(PermissionNames.Hr_Employees, L("Employees"));
            context.CreatePermission(PermissionNames.Hr_Employees_Create, L("CreateNewEmployee"));
            context.CreatePermission(PermissionNames.Hr_Employees_Update, L("EditEmployee"));
            context.CreatePermission(PermissionNames.Hr_Employees_Delete, L("DeleteEmployee"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SouccarConsts.LocalizationSourceName);
        }
    }
}
