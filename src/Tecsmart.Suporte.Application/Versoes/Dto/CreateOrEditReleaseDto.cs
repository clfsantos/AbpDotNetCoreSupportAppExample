using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Releases.Dto
{
    public class CreateOrEditReleaseDto : EntityDto<int?>
    {
        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? ProdutoId { get; set; }

        [DisplayName("Vers�o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Versao { get; set; }

        [DisplayName("Altera��es")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [DisplayName("Data da Release")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public DateTime? DataRelease { get; set; }

    }
}
