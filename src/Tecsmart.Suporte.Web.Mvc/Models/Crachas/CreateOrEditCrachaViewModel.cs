using Tecsmart.Suporte.Crachas.Dto;

namespace Tecsmart.Suporte.Web.Models.Crachas
{
    public class CreateOrEditCrachaViewModel
    {
        public CreateOrEditCrachaDto Cracha { get; set; }
        public bool IsEditMode => Cracha.Id.HasValue;
    }
}
