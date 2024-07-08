using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Souccar.Authorization
{
    public class SouccarAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            #region Others
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Administration_HangfireDashboard, L("HangfireDashboard"));

            //Employee
            context.CreatePermission(PermissionNames.Pages_Employee, L("Employee"));
            context.CreatePermission(PermissionNames.Pages_Employee_Create, L("CreateNewEmployee"));
            context.CreatePermission(PermissionNames.Pages_Employee_Edit, L("EditEmployee"));
            context.CreatePermission(PermissionNames.Pages_Employee_Delete, L("DeleteEmployee"));

            //Child
            context.CreatePermission(PermissionNames.Pages_Child, L("Child"));
            context.CreatePermission(PermissionNames.Pages_Child_Create, L("CreateNewChild"));
            context.CreatePermission(PermissionNames.Pages_Child_Edit, L("EditChild"));
            context.CreatePermission(PermissionNames.Pages_Child_Delete, L("DeleteChild"));
            #endregion


            #region Security Module
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
            #endregion


            #region Setting Module
            //GeneralSettings
            context.CreatePermission(PermissionNames.Setting_GeneralSettings, L("GeneralSettings"));
            context.CreatePermission(PermissionNames.Setting_GeneralSettings_Create, L("CreateNewGeneralSetting"));
            context.CreatePermission(PermissionNames.Setting_GeneralSettings_Edit, L("EditGeneralSetting"));
            context.CreatePermission(PermissionNames.Setting_GeneralSettings_Delete, L("DeleteGeneralSetting"));

            //Materials
            context.CreatePermission(PermissionNames.Setting_Materials, L("Materials"));
            context.CreatePermission(PermissionNames.Setting_Materials_Create, L("CreateNewMaterial"));
            context.CreatePermission(PermissionNames.Setting_Materials_Edit, L("EditMaterial"));
            context.CreatePermission(PermissionNames.Setting_Materials_Delete, L("DeleteMaterial"));

            //Products
            context.CreatePermission(PermissionNames.Setting_Products, L("Products"));
            context.CreatePermission(PermissionNames.Setting_Products_Create, L("CreateNewProduct"));
            context.CreatePermission(PermissionNames.Setting_Products_Edit, L("EditProduct"));
            context.CreatePermission(PermissionNames.Setting_Products_Delete, L("DeleteProduct"));

            //Categories
            context.CreatePermission(PermissionNames.Setting_Categories, L("Categories"));
            context.CreatePermission(PermissionNames.Setting_Categories_Create, L("CreateNewCategory"));
            context.CreatePermission(PermissionNames.Setting_Categories_Edit, L("EditCategory"));
            context.CreatePermission(PermissionNames.Setting_Categories_Delete, L("DeleteCategory"));

            //Suppliers
            context.CreatePermission(PermissionNames.Setting_Suppliers, L("Suppliers"));
            context.CreatePermission(PermissionNames.Setting_Suppliers_Create, L("CreateNewSupplier"));
            context.CreatePermission(PermissionNames.Setting_Suppliers_Edit, L("EditSupplier"));
            context.CreatePermission(PermissionNames.Setting_Suppliers_Delete, L("DeleteSupplier"));

            //Units
            context.CreatePermission(PermissionNames.Setting_Units, L("Units"));
            context.CreatePermission(PermissionNames.Setting_Units_Create, L("CreateNewUnit"));
            context.CreatePermission(PermissionNames.Setting_Units_Edit, L("EditUnit"));
            context.CreatePermission(PermissionNames.Setting_Units_Delete, L("DeleteUnit"));

            //Transfers
            context.CreatePermission(PermissionNames.Setting_Transfers, L("Transfers"));
            context.CreatePermission(PermissionNames.Setting_Transfers_Create, L("CreateNewTransfer"));
            context.CreatePermission(PermissionNames.Setting_Transfers_Edit, L("EditTransfer"));
            context.CreatePermission(PermissionNames.Setting_Transfers_Delete, L("DeleteTransfer"));
            #endregion


            #region Warehouses Module
            //Warehouses
            context.CreatePermission(PermissionNames.Warehouses_Warehouses, L("Warehouses"));
            context.CreatePermission(PermissionNames.Warehouses_Warehouses_Create, L("CreateNewWarehouse"));
            context.CreatePermission(PermissionNames.Warehouses_Warehouses_Edit, L("EditWarehouse"));
            context.CreatePermission(PermissionNames.Warehouses_Warehouses_Delete, L("DeleteWarehouse"));

            //WarehouseMaterials
            context.CreatePermission(PermissionNames.Warehouses_WarehouseMaterials, L("WarehouseMaterials"));
            context.CreatePermission(PermissionNames.Warehouses_WarehouseMaterials_Create, L("CreateNewWarehouseMaterial"));
            context.CreatePermission(PermissionNames.Warehouses_WarehouseMaterials_Edit, L("EditWarehouseMaterial"));
            context.CreatePermission(PermissionNames.Warehouses_WarehouseMaterials_Delete, L("DeleteWarehouseMaterial"));

            //OutputRquests
            context.CreatePermission(PermissionNames.Warehouses_OutputRquests, L("OutputRquests"));
            context.CreatePermission(PermissionNames.Warehouses_OutputRquests_Create, L("CreateNewOutputRquest"));
            context.CreatePermission(PermissionNames.Warehouses_OutputRquests_Edit, L("EditOutputRquest"));
            context.CreatePermission(PermissionNames.Warehouses_OutputRquests_Delete, L("DeleteOutputRquest"));
            #endregion


            #region Production Module
            //DailyProductions
            context.CreatePermission(PermissionNames.Production_DailyProductions, L("DailyProductions"));
            context.CreatePermission(PermissionNames.Production_DailyProductions_Create, L("CreateNewDailyProduction"));
            context.CreatePermission(PermissionNames.Production_DailyProductions_Edit, L("EditDailyProduction"));
            context.CreatePermission(PermissionNames.Production_DailyProductions_Delete, L("DeleteDailyProduction"));

            //Plans
            context.CreatePermission(PermissionNames.Production_Plans, L("Plans"));
            context.CreatePermission(PermissionNames.Production_Plans_Create, L("CreateNewPlan"));
            context.CreatePermission(PermissionNames.Production_Plans_Edit, L("EditPlan"));
            context.CreatePermission(PermissionNames.Production_Plans_Delete, L("DeletePlan"));
            #endregion


            #region Workflow Module
            //Workflows
            context.CreatePermission(PermissionNames.Workflow, L("Workflow"));
            context.CreatePermission(PermissionNames.Workflow_Create, L("CreateWorkflow"));
            context.CreatePermission(PermissionNames.Workflow_Edit, L("EditWorkflow"));
            context.CreatePermission(PermissionNames.Workflow_Delete, L("DeleteWorkflow"));

            //Workflow Steps
            context.CreatePermission(PermissionNames.Workflow_Step, L("WorkflowStep"));
            context.CreatePermission(PermissionNames.Workflow_Step_Create, L("CreateWorkflowStep"));
            context.CreatePermission(PermissionNames.Workflow_Step_Edit, L("EditWorkflowStep"));
            context.CreatePermission(PermissionNames.Workflow_Step_Delete, L("DeleteWorkflowStep"));

            //Workflow Steps Indexes
            context.CreatePermission(PermissionNames.Workflow_Step_Index, L("WorkflowStepIndex"));
            context.CreatePermission(PermissionNames.Workflow_Step_Index_Create, L("CreateWorkflowStepIndex"));
            context.CreatePermission(PermissionNames.Workflow_Step_Index_Edit, L("EditWorkflowStepIndex"));
            context.CreatePermission(PermissionNames.Workflow_Step_Index_Delete, L("DeleteWorkflowStepIndex"));
            #endregion

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, SouccarConsts.LocalizationSourceName);
        }
    }
}
