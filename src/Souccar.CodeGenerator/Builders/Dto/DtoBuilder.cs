using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Souccar.CodeGenerator
{
    public class DtoBuilder
    {
        private readonly Type _entityType;
        private readonly string _prefix;
        private readonly bool _isLowerCase;
        private StringBuilder builder;
        public DtoBuilder(Type entityType, string prefix = "", bool isLowerCase = false)
        {
            _entityType = entityType;
            _prefix = prefix;
            _isLowerCase = isLowerCase;
            builder = new StringBuilder();
        }
        public string Generate()
        {
            var className = _entityType.Name;
            var namespac = _entityType.Namespace;

            builder.AppendLine("using System;");
            builder.AppendLine("using Abp.Application.Services.Dto;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Dto");
            builder.AppendLine("{");

            //class
            GenerateClass();

            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateClass()
        {
            builder.AppendLine($"   public class {_prefix}{_entityType.Name}Dto  {(_prefix.Equals("Create",StringComparison.OrdinalIgnoreCase)  ? "" : ": EntityDto<" + GeneralSetting.DataTypeId + ">")}");
            builder.AppendLine("    {");

            #region properties
           
            var properties = _entityType.GetProperties(BindingFlags.Public
                                                        | BindingFlags.Instance
                                                        | BindingFlags.DeclaredOnly);
            foreach (var propInfo in properties)
            {
                GenerateProperty(propInfo);
            }

            #endregion

            builder.AppendLine("    }");
        }

        public string GeneratePagedRequest(string className)
        {
            var namespac = _entityType.Namespace;

            builder.AppendLine("using System;");
            builder.AppendLine("using Souccar.Core.Includes;");
            builder.AppendLine("using Abp.Application.Services.Dto;");
            builder.AppendLine("");

            //namespace
            builder.AppendLine($"namespace {namespac}.Dto");
            builder.AppendLine("{");
            builder.AppendLine($"   public class {className} : PagedResultRequestDto, ISortedResultRequest, IIncludeResultRequest");
            builder.AppendLine("    {");


            builder.AppendLine($"        public string Keyword " + "{ get; set; }");
            builder.AppendLine($"        public string Sorting " + "{ get; set; }");
            builder.AppendLine($"        public string Including " + "{ get; set; }");

            builder.AppendLine("    }");
            builder.AppendLine("}");

            return builder.ToString();
        }

        private void GenerateProperty(PropertyInfo propInfo)
        {
            var propText = propInfo.GetText(_isLowerCase);
            if (!string.IsNullOrEmpty(propText))
            {
                builder.AppendLine($"        {propText}");
            }
        }
    }
}
