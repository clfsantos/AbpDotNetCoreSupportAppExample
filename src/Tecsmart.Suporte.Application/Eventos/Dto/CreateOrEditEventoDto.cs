using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Eventos.Dto
{
    public class CreateOrEditEventoDto : EntityDto<int?>
    {
        [DisplayName("Descri��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [DisplayName("Prioridade")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? PrioridadeId { get; set; }
    }
}
