using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;

namespace Tecsmart.Suporte.FilaAtendimentos.Dto
{
    public class CreateOrEditFilaRetornoDto : EntityDto<int?>, IShouldNormalize
    {
        public int FilaAtendimentoId { get; set; }

        public DateTime DataRetorno { get; set; }

        [DisplayName("Tipo Retorno")]
        public int TipoRetorno { get; set; }

        [DisplayName("Observação")]
        public string Observacao { get; set; }
        
        public long? UsuarioId { get; set; }


        public void Normalize()
        {
            if (Id == null)
            {
                DataRetorno = DateTime.Now;
            }

        }
    }
}
