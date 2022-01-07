using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Web.Models.Chamados
{
    public class CreateOrEditAssistenciaViewModel
    {
        public CreateOrEditAssistenciaDto Assistencia { get; set; }
        public bool IsEditMode => Assistencia.Id.HasValue;

    }
}
