using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Modelos.Dto
{
    public class CreateOrEditModeloDto : EntityDto<int?>
    {
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? CategoriaId { get; set; }

        [DisplayName("Fabricante")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int? FabricanteId { get; set; }

    }
}
