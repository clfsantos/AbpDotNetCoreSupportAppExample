using Tecsmart.Suporte.FilaAtendimentos.Dto;

namespace Tecsmart.Suporte.Web.Models.FilaAtendimentos
{
    public class CreateOrEditFilaRetornoViewModel
    {
        public CreateOrEditFilaRetornoDto FilaRetorno { get; set; }
        public bool IsEditMode => FilaRetorno.Id.HasValue;

    }
}
