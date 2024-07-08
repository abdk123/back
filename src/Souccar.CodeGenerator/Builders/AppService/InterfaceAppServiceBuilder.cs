using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.CodeGenerator
{
    internal class InterfaceAppServiceBuilder
    {
        private readonly Type _entityType;
        private StringBuilder builder;

        public InterfaceAppServiceBuilder(Type entityType)
        {
            _entityType = entityType;
            this.builder = new StringBuilder();
        }

        public string Generate()
        {
            var entityName = _entityType.Name;
            var namespac = _entityType.Namespace;
            var idDataType = GeneralSetting.DataTypeId;

            #region Generic dto names
            var readDto = $"Read{entityName}Dto";
            var pagedDto = $"Paged{entityName}RequestDto";
            var createDto = $"Create{entityName}Dto";
            var updateDto = $"Update{entityName}Dto";

            #endregion

            //builder.AddDefaultNamespaces();
            builder.AppendLine("using Souccar.Core.Services;");
            builder.AppendLine($"using {namespac}.Dto;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public interface I{entityName}AppService : IAsyncSouccarAppService<{entityName},{idDataType},{pagedDto},{createDto},{updateDto}>");
            builder.AppendLine( "    {");
            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}
