namespace Souccar.Models.Migrations
{
    public class ClearDatabaseOutput
    {
        public string ErrorMessage { get; set; }

        public ClearDatabaseOutput(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
