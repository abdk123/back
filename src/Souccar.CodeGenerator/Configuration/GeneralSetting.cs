namespace Souccar.CodeGenerator
{
    public class GeneralSetting
    {
        public static int FileCount;
        public const string DataTypeId = "int";
        public const string ProjectName = "Souccar";
        public const string LocalizationFile = "Souccar.xml";
        public const string AppServiceBase = "SouccarAppServiceBase";
        public const string AsyncSouccarAppService = "AsyncSouccarAppService";
        public const string ISouccarDomainService = "ISouccarDomainService";
        public const string ProjectRootPath = @"C:\Projects\Framework\aspnet-core\src\";
        public const string ProjectAppPath = ProjectRootPath + @"Souccar.Application\";
        public const string ProjectDomainPath = ProjectRootPath + @"Souccar.Core";
        public const string DbContextFilePath =  ProjectRootPath + @"Souccar.EntityFrameworkCore\EntityFrameworkCore\SouccarDbContext.cs";
        public const string PermissionsFilePath = ProjectRootPath + @"Souccar.Core\Authorization\PermissionNames.cs";
    }
}
