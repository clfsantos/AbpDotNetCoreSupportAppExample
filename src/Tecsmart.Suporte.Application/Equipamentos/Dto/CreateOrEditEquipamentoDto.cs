using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Equipamentos.Dto
{
    public class CreateOrEditEquipamentoDto : EntityDto<int?>, IShouldNormalize
    {
        [DisplayName("N�mero de s�rie")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")] 
        public int? ClienteId { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? ModeloId { get; set; }

        [DisplayName("Testado")]
        public bool TesteOk { get; set; }

        [DisplayName("Inativar")]
        public bool Inativo { get; set; }

        [DisplayName("Data de inclus�o")]
        public virtual DateTime? DataInclusao { get; set; }

        public void Normalize()
        {
            if (!Id.HasValue)
            {
                DataInclusao = DateTime.Now;
            }
        }

    }
}
