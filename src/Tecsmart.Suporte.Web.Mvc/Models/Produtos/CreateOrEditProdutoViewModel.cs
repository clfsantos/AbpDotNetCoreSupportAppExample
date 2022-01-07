using Tecsmart.Suporte.Produtos.Dto;

namespace Tecsmart.Suporte.Web.Models.Produtos
{
    public class CreateOrEditProdutoViewModel
    {
        public CreateOrEditProdutoDto Produto { get; set; }
        public bool IsEditMode => Produto.Id.HasValue;
    }
}
