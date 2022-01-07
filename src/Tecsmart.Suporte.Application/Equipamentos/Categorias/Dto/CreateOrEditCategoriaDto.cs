using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Equipamentos.Categorias.Dto
{
    public class CreateOrEditCategoriaDto : EntityDto<int?>
    {
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Descricao { get; set; }

    }
}
