using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Equipamentos.Fabricantes.Dto
{
    public class FabricanteDto : EntityDto<int>
    {
        public string Nome { get; set; }
    }
}
