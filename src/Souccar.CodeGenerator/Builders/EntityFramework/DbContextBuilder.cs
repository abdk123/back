using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.CodeGenerator
{
    public class DbContextBuilder
    {
        public static void Generate(Assembly assembly, string moduleName)
        {
            Console.WriteLine($"Module : {moduleName}");
            var entities = assembly.GetTypes()
             .Where(t => t.Namespace.Contains($"{GeneralSetting.ProjectName}.{moduleName}")
              && t.BaseType != null
              && (t.BaseType != null
              && t.BaseType.FullName.Contains("Entity") || t.BaseType.FullName.Contains("FullAuditedAggregateRoot"))
              && t.Name == "Test"
              && t.IsClass == true).ToList();

            if (entities.Any())
            {
                var list = GetUndefinedEntities(entities);
                
                var text = GenerateDbSet(list);
                Console.WriteLine(text);
            }
        }

        private static List<string> GetUndefinedEntities(List<Type> entities)
        {
            var list = new List<string>();
            using(var reader = new StreamReader(GeneralSetting.DbContextFilePath))
            {
                var text = reader.ReadToEnd();
                foreach(var entity in entities)
                {
                    var dbSet = $"DbSet<{entity.Name}>";
                    if (!text.Contains(dbSet))
                    {
                        list.Add(entity.Name);
                    }
                }
            }

            return list;
        }

        private static string GenerateDbSet(List<string> list)
        {
            var builder = new StringBuilder();
            foreach (var item in list)
            {
                var dbSet = "public DbSet<" + item + "> " + item + "{ get; set; }";
                builder.AppendLine(dbSet);
            }
            return builder.ToString();
        }
    }
}
