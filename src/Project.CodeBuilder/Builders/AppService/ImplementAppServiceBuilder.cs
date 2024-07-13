using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.CodeGenerator
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
            var namespac = _entityType.Namespace;

            builder.AddDefaultNamespaces();
            builder.AppendLine($"using {namespac}.Dto;");
            builder.AppendLine("using Microsoft.AspNetCore.Mvc;");
            builder.AppendLine("using Abp.Application.Services.Dto;");
            builder.AppendLine("using System.Collections;");
            builder.AppendLine("using System.Linq;");
            builder.AppendLine("using System.Linq.Dynamic.Core;");
            builder.AppendLine("using Abp.Extensions;");
            builder.AppendLine("using Abp.Linq.Extensions;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Services");
            builder.AppendLine("{");

            builder.AppendLine($"    public class {entityName}AppService : {GeneralSetting.AppServiceBase}, I{entityName}AppService");
            builder.AppendLine("    {");

            builder.AppendLine($"        private readonly I{entityName}DomainService _{paramName}DomainService;");
            builder.AppendLine($"        public {entityName}AppService(I{entityName}DomainService {paramName}DomainService)");
            builder.AppendLine("        {");
            builder.AppendLine($"            _{paramName}DomainService = {paramName}DomainService;");
            builder.AppendLine("        }");

            GenerateGetQueryable(builder, entityName, paramName);
            GenerateGetAllAsync(builder, entityName, paramName);
            GenerateGetByIdAsync(builder, entityName, paramName, idDataType);
            GenerateForEditAsync(builder, entityName, paramName, idDataType);
            GenerateCreateAsync(builder, entityName, paramName);
            GenerateUpdateAsync(builder, entityName, paramName);
            GenerateDeleteAsync(builder, entityName, paramName);
            GenerateApplyPagingAsync(builder, entityName, paramName);
            GenerateApplySortingAsync(builder, entityName, paramName);

            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateDeleteAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task DeleteAsync({GeneralSetting.DataTypeId} id)");
            builder.AppendLine("        {");
            builder.AppendLine($"            await _{paramName}DomainService.DeleteAsync(id);");
            builder.AppendLine("        }");
        }

        private void GenerateUpdateAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<Update{entityName}Dto> UpdateAsync(Update{entityName}Dto {paramName}Dto)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = ObjectMapper.Map<{entityName}>({paramName}Dto);");
            builder.AppendLine($"            var updated{entityName} = await _{paramName}DomainService.UpdateAsync({paramName});");
            builder.AppendLine($"            return ObjectMapper.Map<Update{entityName}Dto>(updated{entityName});");
            builder.AppendLine("        }");
        }

        private void GenerateCreateAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public async Task<Create{entityName}Dto> CreateAsync(Create{entityName}Dto {paramName}Dto)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = ObjectMapper.Map<{entityName}>({paramName}Dto);");
            builder.AppendLine($"            var created{entityName} = await _{paramName}DomainService.CreateAsync({paramName});");
            builder.AppendLine($"            return ObjectMapper.Map<Create{entityName}Dto>(created{entityName});");
            builder.AppendLine("        }");
        }

        private void GenerateGetByIdAsync(StringBuilder builder, string entityName, string paramName, string idDataType)
        {
            builder.AppendLine($"        public async Task<{entityName}Dto> GetByIdAsync({idDataType} id)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = await _{paramName}DomainService.GetByIdAsync(id);");
            builder.AppendLine($"            return ObjectMapper.Map<{entityName}Dto>({paramName});");
            builder.AppendLine("        }");
        }

        private void GenerateForEditAsync(StringBuilder builder, string entityName, string paramName, string idDataType)
        {
            builder.AppendLine($"        public async Task<Update{entityName}Dto> GetForEditAsync({idDataType} id)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var {paramName} = await _{paramName}DomainService.GetByIdAsync(id);");
            builder.AppendLine($"            return ObjectMapper.Map<Update{entityName}Dto>({paramName});");
            builder.AppendLine("        }");
        }

        private void GenerateGetQueryable(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public PagedResultDto<{entityName}Dto> Read(Paged{entityName}ResultRequestDto input)");
            builder.AppendLine("        {");
            builder.AppendLine($"            var query = _{paramName}DomainService.Filter(input.Keyword);");
            builder.AppendLine($"            var totalCount = query.Count();");
            builder.AppendLine($"            query = ApplySorting(query, input);");
            builder.AppendLine($"            query = ApplyPaging(query, input);");
            builder.AppendLine($"            var data = ObjectMapper.Map<List<{entityName}Dto>>(query);");
            builder.AppendLine($"            return new PagedResultDto<{entityName}Dto>(");
            builder.AppendLine($"                totalCount,");
            builder.AppendLine("                 data");
            builder.AppendLine( "            );");            
            builder.AppendLine("        }");
        }

        private void GenerateGetAllAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"        public IList<{entityName}Dto> GetAll()");
            builder.AppendLine("        {");
            builder.AppendLine($"            var list = _{paramName}DomainService.GetAll();");
            builder.AppendLine($"            return ObjectMapper.Map<IList<{entityName}Dto>>(list);");
            builder.AppendLine("        }");
        }

        private void GenerateApplyPagingAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"       protected virtual IQueryable<{entityName}> ApplyPaging(IQueryable<{entityName}> query, Paged{entityName}ResultRequestDto input)");
            builder.AppendLine("       {");
            builder.AppendLine($"            var pagedInput = input as IPagedResultRequest;");
            builder.AppendLine($"            if (pagedInput != null)");
            builder.AppendLine("             {");
            builder.AppendLine("                return query.PageBy(pagedInput);");
            builder.AppendLine("             }");
            builder.AppendLine("");
            builder.AppendLine($"            var limitedInput = input as ILimitedResultRequest;");
            builder.AppendLine($"            if (limitedInput != null)");
            builder.AppendLine("             {");
            builder.AppendLine("                return query.Take(limitedInput.MaxResultCount);");
            builder.AppendLine("             }");
            builder.AppendLine($"            return query;");
            builder.AppendLine("       }");
        }

        private void GenerateApplySortingAsync(StringBuilder builder, string entityName, string paramName)
        {
            builder.AppendLine($"       protected virtual IQueryable<{entityName}> ApplySorting(IQueryable<{entityName}> query, Paged{entityName}ResultRequestDto input)");
            builder.AppendLine("       {");
            builder.AppendLine($"            var sortInput = input as ISortedResultRequest;");
            builder.AppendLine($"            if (sortInput != null)");
            builder.AppendLine("             {");
            builder.AppendLine("                if (!sortInput.Sorting.IsNullOrWhiteSpace())");
            builder.AppendLine("                {");
            builder.AppendLine("                    return query.OrderBy(sortInput.Sorting);");
            builder.AppendLine("                }");
            builder.AppendLine("             }");
            builder.AppendLine("");
            builder.AppendLine($"            if (input is ILimitedResultRequest)");
            builder.AppendLine("             {");
            builder.AppendLine("                return query.OrderByDescending(e => e.Id);");
            builder.AppendLine("             }");
            builder.AppendLine($"            return query;");
            builder.AppendLine("       }");

        }
    }
}
