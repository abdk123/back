namespace Souccar.CodeGenerator
{
    internal class DomainBuilder
    {
        public static void Generate(Type entityType)
        {
            var folderPath = entityType.Namespace.DomainEntityPath();

            GenerateDomainService(entityType, folderPath);
            
        }

        private static void GenerateDomainService(Type entityType, string folderPath)
        {
            var path = Path.Combine(folderPath, "Services");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Class
            var classFileName = $"{entityType.Name}Manager.cs";
            var classFilePath = Path.Combine(path, classFileName);

            if (!File.Exists(classFilePath))
            {
                var builder = new ImplementDomainServiceBuilder(entityType);
                var classText = builder.Generate();

                CreateCsFile(classText, classFilePath);
            }

            //Interfcae
            var interfaceFileName = $"I{entityType.Name}Manager.cs";
            var interfaceFilePath = Path.Combine(path, interfaceFileName);

            if (!File.Exists(interfaceFilePath))
            {
                var builder = new InterfaceDomainServiceBuilder(entityType);
                var interfaceText = builder.Generate();

                CreateCsFile(interfaceText, interfaceFilePath);
            }
        }
        private static void CreateCsFile(string text, string path)
        {
            var sw = new StreamWriter(path);
            sw.WriteLine(text);
            sw.Close();
            Thread.Sleep(50);

            Console.WriteLine(path);
            GeneralSetting.FileCount++;
        }
    }
}
