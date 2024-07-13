using Project.CodeGenerator;
using Souccar.SaleManagement.Settings.Companies;

namespace Bwire.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Files : ");
            var assembly = typeof(Company).Assembly;
            ModulesBuilder.Generate(assembly, "SaleManagement");
            //LocalizationBuilder.Generate(assembly, "SaleManagement");
            //DbContextBuilder.Generate(assembly, "SaleManagement");
            //PermissionsBuilder.Generate(assembly, "SaleManagement");

            Console.WriteLine("Files : " + GeneralSetting.FileCount);
        }
    }
}