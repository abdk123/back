using System.ComponentModel.DataAnnotations;

namespace Souccar.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}