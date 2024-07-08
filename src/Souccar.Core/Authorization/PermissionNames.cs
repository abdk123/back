namespace Souccar.Authorization
{
    public static class PermissionNames
    {
        #region Others
        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Users_Activation = "Pages.Users.Activation";

        //Employee
        public const string Pages_Employee = "Pages.Employee";
        public const string Pages_Employee_Create = "Pages.Employee.Create";
        public const string Pages_Employee_Edit = "Pages.Employee.Edit";
        public const string Pages_Employee_Delete = "Pages.Employee.Delete";

        //Child
        public const string Pages_Child = "Pages.Child";
        public const string Pages_Child_Create = "Pages.Child.Create";
        public const string Pages_Child_Edit = "Pages.Child.Edit";
        public const string Pages_Child_Delete = "Pages.Child.Delete";


        //Nationalities
        public const string Pages_Nationalities = "Pages.Nationalities";
        public const string Pages_Nationalities_Create = "Pages.Nationalities.Create";
        public const string Pages_Nationalities_Edit = "Pages.Nationalities.Edit";
        public const string Pages_Nationalities_Delete = "Pages.Nationalities.Delete";

        //Hangfire
        public const string Pages_Administration_HangfireDashboard = "Pages.Administration.HangfireDashboard";
        #endregion


        #region Security Module
        //Users
        public const string Security_Users = "Security.Users";
        public const string Security_Users_Create = "Security.Users.Create";
        public const string Security_Users_Edit = "Security.Users.Edit";
        public const string Security_Users_Delete = "Security.Users.Delete";
        public const string Security_Users_ResetPassword = "Security.Users.ResetPassword";
        public const string Security_Users_ChangePermissions = "Security.Users.ChangePermissions";

        //Roles
        public const string Security_Roles = "Security.Roles";
        public const string Security_Roles_Create = "Security.Roles.Create";
        public const string Security_Roles_Edit = "Security.Roles.Edit";
        public const string Security_Roles_Delete = "Security.Roles.Delete";
        #endregion


        #region Setting Module
        //Materials
        public const string Setting_Materials = "Setting.Materials";
        public const string Setting_Materials_Create = "Setting.Materials.Create";
        public const string Setting_Materials_Edit = "Setting.Materials.Edit";
        public const string Setting_Materials_Delete = "Setting.Materials.Delete";

        //Products
        public const string Setting_Products = "Setting.Products";
        public const string Setting_Products_Create = "Setting.Products.Create";
        public const string Setting_Products_Edit = "Setting.Products.Edit";
        public const string Setting_Products_Delete = "Setting.Products.Delete";

        //Categories
        public const string Setting_Categories = "Setting.Categories";
        public const string Setting_Categories_Create = "Setting.Categories.Create";
        public const string Setting_Categories_Edit = "Setting.Categories.Edit";
        public const string Setting_Categories_Delete = "Setting.Categories.Delete";

        //Suppliers
        public const string Setting_Suppliers = "Setting.Suppliers";
        public const string Setting_Suppliers_Create = "Setting.Suppliers.Create";
        public const string Setting_Suppliers_Edit = "Setting.Suppliers.Edit";
        public const string Setting_Suppliers_Delete = "Setting.Suppliers.Delete";

        //Units
        public const string Setting_Units = "Setting.Units";
        public const string Setting_Units_Create = "Setting.Units.Create";
        public const string Setting_Units_Edit = "Setting.Units.Edit";
        public const string Setting_Units_Delete = "Setting.Units.Delete";

        //Transfers
        public const string Setting_Transfers = "Setting.Transfers";
        public const string Setting_Transfers_Create = "Setting.Transfers.Create";
        public const string Setting_Transfers_Edit = "Setting.Transfers.Edit";
        public const string Setting_Transfers_Delete = "Setting.Transfers.Delete";

        //GeneralSettings
        public const string Setting_GeneralSettings = "Setting.GeneralSettings";
        public const string Setting_GeneralSettings_Create = "Setting.GeneralSettings.Create";
        public const string Setting_GeneralSettings_Edit = "Setting.GeneralSettings.Edit";
        public const string Setting_GeneralSettings_Delete = "Setting.GeneralSettings.Delete";
        #endregion


        #region Warehouses Module
        //WarehouseMaterials
        public const string Warehouses_WarehouseMaterials = "Warehouses.WarehouseMaterials";
        public const string Warehouses_WarehouseMaterials_Create = "Warehouses.WarehouseMaterials.Create";
        public const string Warehouses_WarehouseMaterials_Edit = "Warehouses.WarehouseMaterials.Edit";
        public const string Warehouses_WarehouseMaterials_Delete = "Warehouses.WarehouseMaterials.Delete";

        //Warehouses
        public const string Warehouses_Warehouses = "Warehouses.Warehouses";
        public const string Warehouses_Warehouses_Create = "Warehouses.Warehouses.Create";
        public const string Warehouses_Warehouses_Edit = "Warehouses.Warehouses.Edit";
        public const string Warehouses_Warehouses_Delete = "Warehouses.Warehouses.Delete";

        //OutputRquests
        public const string Warehouses_OutputRquests = "Warehouses.OutputRquests";
        public const string Warehouses_OutputRquests_Create = "Warehouses.OutputRquests.Create";
        public const string Warehouses_OutputRquests_Edit = "Warehouses.OutputRquests.Edit";
        public const string Warehouses_OutputRquests_Delete = "Warehouses.OutputRquests.Delete";
        #endregion


        #region Production Module
        //Plans
        public const string Production_Plans = "Production.Plans";
        public const string Production_Plans_Create = "Production.Plans.Create";
        public const string Production_Plans_Edit = "Production.Plans.Edit";
        public const string Production_Plans_Delete = "Production.Plans.Delete";

        //DailyProductions
        public const string Production_DailyProductions = "Production.DailyProductions";
        public const string Production_DailyProductions_Create = "Production.DailyProductions.Create";
        public const string Production_DailyProductions_Edit = "Production.DailyProductions.Edit";
        public const string Production_DailyProductions_Delete = "Production.DailyProductions.Delete";
        #endregion


        #region Workflow Module
        //Workflows
        public const string Workflow = "Workflow.Workflow";
        public const string Workflow_Create = "Workflow.Workflow.Create";
        public const string Workflow_Edit = "Workflow.Workflow.Edit";
        public const string Workflow_Delete = "Workflow.Workflow.Delete";

        //Workflow Steps
        public const string Workflow_Step = "Workflow.WorkflowStep";
        public const string Workflow_Step_Create = "Workflow.WorkflowStep.Create";
        public const string Workflow_Step_Edit = "Workflow.WorkflowStep.Edit";
        public const string Workflow_Step_Delete = "Workflow.WorkflowStep.Delete";

        //Workflow Steps Indexes
        public const string Workflow_Step_Index = "Workflow.StepIndex";
        public const string Workflow_Step_Index_Create = "Workflow.StepIndex.Create";
        public const string Workflow_Step_Index_Edit = "Workflow.StepIndex.Edit";
        public const string Workflow_Step_Index_Delete = "Workflow.StepIndex.Delete";
        #endregion

    }
}
