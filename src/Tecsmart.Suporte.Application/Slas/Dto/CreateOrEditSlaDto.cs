using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Slas.Dto
{
    public class CreateOrEditSlaDto : EntityDto<int?>
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DisplayName("Duração")]
        public TimeSpan? Duracao { get; set; }
    }
}
