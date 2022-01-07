using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Equipamentos.Categorias.Dto
{
    public class CreateOrEditCategoriaDto : EntityDto<int?>
    {
        [DisplayName("Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

    }
}
