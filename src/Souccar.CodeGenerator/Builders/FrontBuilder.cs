using Souccar.CodeGenerator.Builders.Front;

namespace Souccar.CodeGenerator.Builders
{
    public class FrontBuilder
    {
        public static string Generate(string entityName,string page)
        {
            var coreAssembly = typeof(SouccarCoreModule).Assembly;
            var entityType = coreAssembly.GetType(entityName);
            var name = $"{page}{entityType.Name}Dto";
            var appAssembly = typeof(SouccarApplicationModule).Assembly;
            var type = appAssembly.GetTypes().FirstOrDefault(t=>t.Name.Contains(name));
            switch (page)
            {
                case "Read":
                    return FrontReadBuilder.Generate(type);
                default:
                    return string.Empty;
            }
        }
    }
}
