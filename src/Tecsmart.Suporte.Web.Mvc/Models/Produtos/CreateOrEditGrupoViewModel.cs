using Tecsmart.Suporte.Produtos.Dto;

namespace Tecsmart.Suporte.Web.Models.Produtos
{
    public class CreateOrEditGrupoViewModel : GetGrupoForEditOutput
    {
        public bool IsEditMode => Grupo.Id.HasValue;
    }
}
