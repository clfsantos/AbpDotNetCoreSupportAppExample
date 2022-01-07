using Tecsmart.Suporte.Suprimentos.Dto;

namespace Tecsmart.Suporte.Web.Models.Crachas
{
    public class CreateOrEditSuprimentoConsumoViewModel
    {
        public CreateOrEditSuprimentoConsumoDto SuprimentoConsumo { get; set; }
        public bool IsEditMode => SuprimentoConsumo.Id.HasValue;
    }
}
