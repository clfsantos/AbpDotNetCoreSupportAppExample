using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditEtapaChamadoDto : EntityDto<int?>
    {
        [Required]
        public int ChamadoId { get; set; }

        [Required]
        public int EtapaId { get; set; }

        [Required]
        public int EtapaStatusId { get; set; }

        [DisplayName("Observações")]
        public string Observacao { get; set; }

        public DateTime? DataEtapa { get; set; }

        public DateTime? DataConclusao { get; set; }

        [DisplayName("Observações da Recusa")]
        public string ObsRecusada { get; set; }
        
        public DateTime? DataRecusada { get; set; }
    }
}
