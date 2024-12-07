using System.ComponentModel.DataAnnotations;

namespace Souccar.Models.Migrations
{
    public class ClearDatabaseInput
    {
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
