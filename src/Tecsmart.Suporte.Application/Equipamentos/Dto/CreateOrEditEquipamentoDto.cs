using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Equipamentos.Dto
{
    public class CreateOrEditEquipamentoDto : EntityDto<int?>, IShouldNormalize
    {
        [DisplayName("Número de série")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")] 
        public int? ClienteId { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? ModeloId { get; set; }

        [DisplayName("Testado")]
        public bool TesteOk { get; set; }

        [DisplayName("Inativar")]
        public bool Inativo { get; set; }

        [DisplayName("Data de inclusão")]
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
