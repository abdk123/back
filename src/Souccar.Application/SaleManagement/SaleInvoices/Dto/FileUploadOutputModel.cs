namespace Souccar.SaleManagement.SaleInvoices.Dto
{
    public class FileUploadOutputModel
    {
        public FileUploadOutputModel(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public FileUploadOutputModel(bool success, FileOutputModel file)
        {
            Success = success;
            Message = "";
            File = file;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public FileOutputModel File { get; set; }
    }
}
