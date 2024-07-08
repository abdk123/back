﻿using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Souccar.Authorization
{
    public class SouccarAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));

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
            context.CreatePermission(PermissionNames.Pages_Stocks, L("Stock"));
            context.CreatePermission(PermissionNames.Actions_Stocks_Create, L("CreateNewStock"));
            context.CreatePermission(PermissionNames.Actions_Stocks_Update, L("EditStock"));
            context.CreatePermission(PermissionNames.Actions_Stocks_Delete, L("DeleteStock"));

            //Sizes
            context.CreatePermission(PermissionNames.Pages_Sizes, L("Size"));
            context.CreatePermission(PermissionNames.Actions_Sizes_Create, L("CreateNewSize"));
            context.CreatePermission(PermissionNames.Actions_Sizes_Update, L("EditSize"));
            context.CreatePermission(PermissionNames.Actions_Sizes_Delete, L("DeleteSize"));

            //Units
            context.CreatePermission(PermissionNames.Pages_Units, L("Unit"));
            context.CreatePermission(PermissionNames.Actions_Units_Create, L("CreateNewUnit"));
            context.CreatePermission(PermissionNames.Actions_Units_Update, L("EditUnit"));
            context.CreatePermission(PermissionNames.Actions_Units_Delete, L("DeleteUnit"));

            //UnitSizes
            context.CreatePermission(PermissionNames.Pages_UnitSizes, L("UnitSize"));
            context.CreatePermission(PermissionNames.Actions_UnitSizes_Create, L("CreateNewUnitSize"));
            context.CreatePermission(PermissionNames.Actions_UnitSizes_Update, L("EditUnitSize"));
            context.CreatePermission(PermissionNames.Actions_UnitSizes_Delete, L("DeleteUnitSize"));

            //Stores
            context.CreatePermission(PermissionNames.Pages_Stores, L("Store"));
            context.CreatePermission(PermissionNames.Actions_Stores_Create, L("CreateNewStore"));
            context.CreatePermission(PermissionNames.Actions_Stores_Update, L("EditStore"));
            context.CreatePermission(PermissionNames.Actions_Stores_Delete, L("DeleteStore"));

            //Materials
            context.CreatePermission(PermissionNames.Pages_Materials, L("Material"));
            context.CreatePermission(PermissionNames.Actions_Materials_Create, L("CreateNewMaterial"));
            context.CreatePermission(PermissionNames.Actions_Materials_Update, L("EditMaterial"));
            context.CreatePermission(PermissionNames.Actions_Materials_Delete, L("DeleteMaterial"));

            //Customers
            context.CreatePermission(PermissionNames.Pages_Customers, L("Customer"));
            context.CreatePermission(PermissionNames.Actions_Customers_Create, L("CreateNewCustomer"));
            context.CreatePermission(PermissionNames.Actions_Customers_Update, L("EditCustomer"));
            context.CreatePermission(PermissionNames.Actions_Customers_Delete, L("DeleteCustomer"));

            //Companies
            context.CreatePermission(PermissionNames.Pages_Companies, L("Company"));
            context.CreatePermission(PermissionNames.Actions_Companies_Create, L("CreateNewCompany"));
            context.CreatePermission(PermissionNames.Actions_Companies_Update, L("EditCompany"));
            context.CreatePermission(PermissionNames.Actions_Companies_Delete, L("DeleteCompany"));

            //Categories
            context.CreatePermission(PermissionNames.Pages_Categories, L("Category"));
            context.CreatePermission(PermissionNames.Actions_Categories_Create, L("CreateNewCategory"));
            context.CreatePermission(PermissionNames.Actions_Categories_Update, L("EditCategory"));
            context.CreatePermission(PermissionNames.Actions_Categories_Delete, L("DeleteCategory"));

            //Offers
            context.CreatePermission(PermissionNames.Pages_Offers, L("Offer"));
            context.CreatePermission(PermissionNames.Actions_Offers_Create, L("CreateNewOffer"));
            context.CreatePermission(PermissionNames.Actions_Offers_Update, L("EditOffer"));
            context.CreatePermission(PermissionNames.Actions_Offers_Delete, L("DeleteOffer"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SouccarConsts.LocalizationSourceName);
        }
    }
}
