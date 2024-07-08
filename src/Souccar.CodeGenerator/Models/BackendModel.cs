using System.ComponentModel.DataAnnotations;

namespace Souccar.CodeGenerator.Models
{
    public class BackendModel
    {
        [Required]
        public string ModuleName { get; set; }

        [Required]
        public string Entity { get; set; }

        [Required]
        public PageType Page { get; set; }
    }

    public enum GenerateType
    {
        Services,
        Localization,
        Permissions,
        DbSet
    }

    public enum PageType
    {
        Read,
        Create,
        Edit,
        View,
        Filter
    }
}
