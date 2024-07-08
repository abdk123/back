using System.ComponentModel.DataAnnotations;

namespace Souccar.CodeGenerator.Models
{
    public class FrontendModel
    {
        [Required]
        public string ModuleName { get; set; }

        [Required]
        public string Entity { get; set; }

        [Required]
        public PageType Page { get; set; }
    }

   
}
