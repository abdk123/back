using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.CodeGenerator
{
    internal class ImplementAppServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public ImplementAppServiceBuilder(Type entityType)
        {
            _entityType = entityType;
            this.builder = new StringBuilder();
        }

        public string Genetate()
        {
            var entityName = _entityType.Name;
            var paramName = entityName.FirstCharToLowerCase();
            var idDataType = GeneralSetting.DataTypeId;
            var asyncSouccarAppService = GeneralSetting.AsyncSouccarAppService;
            var namespac = _entityType.Namespace;

            #region Generic dto names
            var readDto = $"Read{entityName}Dto";
            var pagedDto = $"Paged{entityName}RequestDto";
            var createDto = $"Create{entityName}Dto";
            var updateDto = $"Update{entityName}Dto";

            #endregion


            //builder.AddDefaultNamespaces();
            builder.AppendLine($"using {namespac}.Dto;");
            builder.AppendLine($"using Souccar.Core.Services;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public class {entityName}AppService : {asyncSouccarAppService}<{entityName},{readDto},{idDataType},{pagedDto},{createDto},{updateDto}>, I{entityName}AppService");
            builder.AppendLine("    {");

            builder.AppendLine($"        private readonly I{entityName}Manager _{paramName}Manager;");
            builder.AppendLine($"        public {entityName}AppService(I{entityName}Manager {paramName}Manager):base({paramName}Manager)");
            builder.AppendLine("        {");
            builder.AppendLine($"            _{paramName}Manager = {paramName}Manager;");
            builder.AppendLine("        }");

          

            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}
