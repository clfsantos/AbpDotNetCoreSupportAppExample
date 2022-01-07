using Tecsmart.Suporte.GridStates.Dto;

namespace Tecsmart.Suporte.Web.Models.GridStates
{
    public class CreateOrEditGridStateViewModel
    {
        public CreateOrEditGridStateDto GridState { get; set; }
        public bool IsEditMode => GridState.Id.HasValue;
    }
}
