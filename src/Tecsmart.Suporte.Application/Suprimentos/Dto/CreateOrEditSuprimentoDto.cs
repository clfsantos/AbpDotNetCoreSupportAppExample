using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Suprimentos.Dto
{
    public class CreateOrEditSuprimentoDto : EntityDto<int?>
    {
        [DisplayName("Descri��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

    }
}
