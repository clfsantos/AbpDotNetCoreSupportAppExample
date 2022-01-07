using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditFollowupDto : EntityDto<int?>, IShouldNormalize
    {
        [DisplayName("Tipo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? Tipo { get; set; }

        [Required]
        public DateTime DataFollowup { get; set; }

        [DisplayName("Followup")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Conteudo { get; set; }

        [Required]
        public long UsuarioId { get; set; }

        [DisplayName("Transferir para")]
        public long? UsuarioTransferenciaId { get; set; }

        [DisplayName("Evento")]
        public int? EventoFollowupId { get; set; }

        [Required]
        public bool Cancelado { get; set; }

        [NotMapped]
        public int ChamadoId { get; set; }

        [NotMapped]
        [DisplayName("Transferir Chamado")]
        public bool TransferirChamado { get; set; }

        public void Normalize()
        {
            if (!Id.HasValue)
            {
                Cancelado = false;
                DataFollowup = DateTime.Now;
            }
        }

    }
}
