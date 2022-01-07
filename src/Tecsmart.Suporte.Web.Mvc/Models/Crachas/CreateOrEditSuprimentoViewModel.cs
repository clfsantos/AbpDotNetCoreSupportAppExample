using Tecsmart.Suporte.Suprimentos.Dto;

namespace Tecsmart.Suporte.Web.Models.Crachas
{
    public class CreateOrEditSuprimentoViewModel
    {
        public CreateOrEditSuprimentoDto Suprimento { get; set; }
        public bool IsEditMode => Suprimento.Id.HasValue;
    }
}
