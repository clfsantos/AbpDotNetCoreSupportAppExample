using Tecsmart.Suporte.Releases.Dto;

namespace Tecsmart.Suporte.Web.Models.Releases
{
    public class CreateOrEditReleaseViewModel
    {
        public CreateOrEditReleaseDto Release { get; set; }
        public bool IsEditMode => Release.Id.HasValue;
    }
}
