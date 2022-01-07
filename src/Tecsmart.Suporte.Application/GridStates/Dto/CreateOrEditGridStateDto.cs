using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.GridStates.Dto
{
    public class CreateOrEditGridStateDto : EntityDto<int?>
    {
        [Required] 
        public long UsuarioId { get; set; }

        [Required]
        public string Tela { get; set; }

        [DisplayName("Descri��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [Required]
        public string State { get; set; }

    }
}
