using System.Text;

namespace Souccar.CodeGenerator
{
    internal class ImplementDomainServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public ImplementDomainServiceBuilder(Type entityType)
        {
            _entityType = entityType;
            this.builder = new StringBuilder();
        }
        public string Generate()
        {
            var entityName = _entityType.Name;
            var paramName = entityName.FirstCharToLowerCase();
            var idDataType = GeneralSetting.DataTypeId;
            var namespac = _entityType.Namespace;

            //builder.AddDefaultNamespaces();
            builder.AppendLine("using Abp.Domain.Repositories;");
            builder.AppendLine("using Souccar.Core.Services.Implements;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public class {entityName}Manager : SouccarDomainService<{entityName},{idDataType}> ,I{entityName}Manager");
            builder.AppendLine( "    {");

            builder.AppendLine($"        private readonly IRepository<{entityName}> _{paramName}Repository;");
            builder.AppendLine($"        public {entityName}Manager(IRepository<{entityName}> {paramName}Repository) :base({paramName}Repository)");
            builder.AppendLine( "        {");
            builder.AppendLine($"            _{paramName}Repository = {paramName}Repository;");
            builder.AppendLine( "        }");
            builder.AppendLine( "    }");
            builder.AppendLine("}");

            return builder.ToString();
        } 
    }
}
