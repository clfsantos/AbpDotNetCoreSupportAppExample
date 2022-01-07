using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Web.Models.Chamados
{
    public class CreateOrEditFluxoViewModel
    {
        public CreateOrEditChamadoFluxoDto ChamadoFluxo { get; set; }
        public bool IsEditMode => ChamadoFluxo.Id.HasValue;

    }
}
