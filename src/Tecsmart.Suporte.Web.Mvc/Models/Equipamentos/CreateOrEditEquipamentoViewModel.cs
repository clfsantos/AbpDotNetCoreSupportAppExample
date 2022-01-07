using Tecsmart.Suporte.Equipamentos.Dto;

namespace Tecsmart.Suporte.Web.Models.Equipamentos
{
    public class CreateOrEditEquipamentoViewModel
    {
        public CreateOrEditEquipamentoDto Equipamento { get; set; }
        public bool IsEditMode => Equipamento.Id.HasValue;
    }
}
