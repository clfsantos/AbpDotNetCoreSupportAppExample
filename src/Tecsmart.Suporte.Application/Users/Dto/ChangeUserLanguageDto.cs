using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}