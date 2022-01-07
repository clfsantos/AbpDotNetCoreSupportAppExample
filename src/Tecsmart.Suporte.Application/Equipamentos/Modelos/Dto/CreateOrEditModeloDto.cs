using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Modelos.Dto
{
    public class CreateOrEditModeloDto : EntityDto<int?>
    {
        [DisplayName("Descri��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? CategoriaId { get; set; }

        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? FabricanteId { get; set; }

    }
}
