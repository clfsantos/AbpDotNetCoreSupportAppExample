using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Suprimentos.Dto
{
    public class CreateOrEditSuprimentoConsumoDto : EntityDto<int?>
    {
        [DisplayName("Data")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime? DataCompra { get; set; }

        [DisplayName("Suprimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? SuprimentoId { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? Quantidade { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [DisplayName("Observações")]
        public string Observacoes { get; set; }

    }
}
