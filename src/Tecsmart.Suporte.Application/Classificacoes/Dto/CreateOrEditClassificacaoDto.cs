using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Classificacoes.Dto
{
    public class CreateOrEditClassificacaoDto : EntityDto<int?>
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DisplayName("Observação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Observacao { get; set; }
    }
}
