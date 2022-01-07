using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.FilaAtendimentos.Dto
{
    public class CreateOrEditFilaAtendimentoDto : EntityDto<int?>, IShouldNormalize
    {
        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? ClienteId { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }

        public DateTime? DataFila { get; set; }

        public bool Atendido { get; set; }

        public int? QtdRetorno { get; set; }

        public bool Cancelado { get; set; }


        public void Normalize()
        {
            if(Id == null)
            {
                DataFila = DateTime.Now;
                QtdRetorno = 1;
            }

        }
    }
}
