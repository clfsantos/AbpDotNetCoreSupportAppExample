using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Web.Models.Chamados
{
    public class CreateOrEditEtapaChamadoViewModel
    {
        public CreateOrEditEtapaChamadoDto EtapaChamado { get; set; }
        public bool IsEditMode => EtapaChamado.Id.HasValue;

    }
}
