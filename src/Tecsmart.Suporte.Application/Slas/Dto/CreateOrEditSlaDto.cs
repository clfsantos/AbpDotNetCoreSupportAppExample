using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Slas.Dto
{
    public class CreateOrEditSlaDto : EntityDto<int?>
    {
        [DisplayName("Descri��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [DisplayName("Dura��o")]
        public TimeSpan? Duracao { get; set; }
    }
}
