using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CodeGenerator
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

        public string Genetate()
        {
            var entityName = _entityType.Name;
            var namespac = _entityType.Namespace;

            builder.AddDefaultNamespaces();
            builder.AppendLine("using Abp.Application.Services;");
            builder.AppendLine($"using {namespac}.Dto;");
            builder.AppendLine("using Microsoft.AspNetCore.Mvc;");
            builder.AppendLine("using Abp.Application.Services.Dto;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public interface I{entityName}AppService : IApplicationService");
            builder.AppendLine( "    {");

            builder.AppendLine($"        PagedResultDto<{entityName}Dto> Read(Paged{entityName}ResultRequestDto input);");
            builder.AppendLine($"        public IList<{entityName}Dto> GetAll();");
            builder.AppendLine($"        Task<{entityName}Dto> GetByIdAsync({GeneralSetting.DataTypeId} id);");
            builder.AppendLine($"        Task<Update{entityName}Dto> GetForEditAsync({GeneralSetting.DataTypeId} id);");
            builder.AppendLine($"        Task<Create{entityName}Dto> CreateAsync(Create{entityName}Dto {entityName.FirstCharToLowerCase()});");
            builder.AppendLine($"        Task<Update{entityName}Dto> UpdateAsync(Update{entityName}Dto {entityName.FirstCharToLowerCase()});");
            builder.AppendLine($"        Task DeleteAsync({GeneralSetting.DataTypeId} id);");

            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }
    }
}
