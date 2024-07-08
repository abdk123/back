using System.Text;

namespace Souccar.CodeGenerator
{
    internal class InterfaceDomainServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public InterfaceDomainServiceBuilder(Type entityType)
        {
            _entityType = entityType;
            this.builder = new StringBuilder();
        }

        public string Generate()
        {
            var entityName = _entityType.Name;
            var namespac = _entityType.Namespace;
            var idDataType = GeneralSetting.DataTypeId;
            var iSouccarDomainService = GeneralSetting.ISouccarDomainService;

            //builder.AddDefaultNamespaces();
            builder.AppendLine("using Souccar.Core.Services.Interfaces;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public interface I{entityName}Manager : {iSouccarDomainService}<{entityName},{idDataType}>");
            builder.AppendLine("    {");
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}
