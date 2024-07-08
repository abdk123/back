using Souccar.CodeGenerator.Models.Fields;
using System.Reflection;

namespace Souccar.CodeGenerator.Reflection
{
    public class EntityHelper
    {
        public static List<ReadFieldModel> GenerateReadFields(Type entityType)
        {
            var fields = new List<ReadFieldModel>();
            var properties = entityType.GetProperties(BindingFlags.Public
                                                        | BindingFlags.Instance
                                                     | BindingFlags.DeclaredOnly).Where(p=>p.Name != "TenantId");
            foreach (var propInfo in properties)
            {
                fields.Add(GenerateReadField(propInfo));
            }

            return fields;
        }

        private static ReadFieldModel GenerateReadField(PropertyInfo propInfo)
        {
            return new ReadFieldModel()
            {
                Name = propInfo.Name,
                FieldType = propInfo.GetFieldUiType()
            };
        }
    }
}
