using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Suprimentos.Dto
{
    public class CreateOrEditSuprimentoConsumoDto : EntityDto<int?>
    {
        [DisplayName("Data")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public DateTime? DataCompra { get; set; }

        [DisplayName("Suprimento")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? SuprimentoId { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? Quantidade { get; set; }

        [DisplayName("Valor")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public decimal Valor { get; set; }

        [DisplayName("Observa��es")]
        public string Observacoes { get; set; }

    }
}
