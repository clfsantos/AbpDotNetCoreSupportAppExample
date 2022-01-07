using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Eventos.Dto
{
    public class CreateOrEditEventoDto : EntityDto<int?>
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DisplayName("Prioridade")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? PrioridadeId { get; set; }
    }
}
