using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditChamadoFluxoDto : EntityDto<int?>, IShouldNormalize
    {
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long UsuarioId { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? ClienteId { get; set; }

        public DateTime DataFluxo { get; set; }


        public void Normalize()
        {
            DataFluxo = DateTime.Now;
        }
    }
}
