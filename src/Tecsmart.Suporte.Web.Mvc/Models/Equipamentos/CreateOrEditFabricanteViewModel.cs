using Tecsmart.Suporte.Equipamentos.Fabricantes.Dto;

namespace Tecsmart.Suporte.Web.Models.Equipamentos.Fabricantes
{
    public class CreateOrEditFabricanteViewModel
    {
        public CreateOrEditFabricanteDto Fabricante { get; set; }
        public bool IsEditMode => Fabricante.Id.HasValue;
    }
}
