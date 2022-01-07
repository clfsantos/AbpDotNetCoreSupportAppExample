using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Web.Models.Chamados
{
    public class CreateOrEditChamadoViewModel
    {
        public CreateOrEditChamadoDto Chamado { get; set; }
        public AssistenciaDto Assistencia { get; set; }
        public bool IsEditMode => Chamado.Id.HasValue;

    }
}
