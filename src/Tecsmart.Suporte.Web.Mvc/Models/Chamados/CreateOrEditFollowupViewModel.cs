using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Web.Models.Chamados
{
    public class CreateOrEditFollowupViewModel
    {
        public CreateOrEditFollowupDto Followup { get; set; }
        public bool IsEditMode => Followup.Id.HasValue;

    }
}
