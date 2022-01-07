using Tecsmart.Suporte.Clientes.Dto;

namespace Tecsmart.Suporte.Web.Models.Clientes
{
    public class CreateOrEditClienteViewModel
    {
        public CreateOrEditClienteDto Cliente { get; set; }
        public bool IsEditMode => Cliente.Id.HasValue;
    }
}
