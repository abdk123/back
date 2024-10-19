namespace Souccar.SaleManagement.SaleInvoices.Dto
{
    public class FileOutputModel
    {
        public FileOutputModel(string path, string fileType, string fileName)
        {
            Path = path;
            FileType = fileType;
            FileName = fileName;
        }

        public string Path { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }
}
