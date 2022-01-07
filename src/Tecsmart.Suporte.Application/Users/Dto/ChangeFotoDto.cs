using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Users.Dto
{
    public class ChangeFotoDto
    {
        [Required]
        public string CaminhoFoto { get; set; }

    }
}
