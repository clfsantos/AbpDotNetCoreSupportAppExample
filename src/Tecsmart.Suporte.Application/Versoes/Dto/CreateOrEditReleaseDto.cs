using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Releases.Dto
{
    public class CreateOrEditReleaseDto : EntityDto<int?>
    {
        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? ProdutoId { get; set; }

        [DisplayName("Versão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Versao { get; set; }

        [DisplayName("Alterações")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DisplayName("Data da Release")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime? DataRelease { get; set; }

    }
}
