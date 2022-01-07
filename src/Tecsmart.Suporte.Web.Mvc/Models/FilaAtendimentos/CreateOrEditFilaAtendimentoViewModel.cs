using Tecsmart.Suporte.FilaAtendimentos.Dto;

namespace Tecsmart.Suporte.Web.Models.FilaAtendimentos
{
    public class CreateOrEditFilaAtendimentoViewModel
    {
        public CreateOrEditFilaAtendimentoDto FilaAtendimento { get; set; }
        public bool IsEditMode => FilaAtendimento.Id.HasValue;

    }
}
