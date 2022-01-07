using Tecsmart.Suporte.Produtos.Dto;

namespace Tecsmart.Suporte.Web.Models.Produtos
{
    public class CreateOrEditSubGrupoViewModel : GetSubGrupoForEditOutput
    {
        public bool IsEditMode => SubGrupo.Id.HasValue;
    }
}
