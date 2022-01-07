using Tecsmart.Suporte.Modelos.Dto;

namespace Tecsmart.Suporte.Web.Models.Equipamentos.Modelos
{
    public class CreateOrEditModeloViewModel
    {
        public CreateOrEditModeloDto Modelo { get; set; }
        public bool IsEditMode => Modelo.Id.HasValue;
    }
}
