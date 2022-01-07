using Tecsmart.Suporte.Equipamentos.Categorias.Dto;

namespace Tecsmart.Suporte.Web.Models.Equipamentos.Categorias
{
    public class CreateOrEditCategoriaViewModel
    {
        public CreateOrEditCategoriaDto Categoria { get; set; }
        public bool IsEditMode => Categoria.Id.HasValue;
    }
}
