using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Classificacoes.Dto
{
    public class CreateOrEditClassificacaoDto : EntityDto<int?>
    {
        [DisplayName("Descri��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [DisplayName("Observa��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Observacao { get; set; }
    }
}
