using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Modelos.Dto
{
    public class ModeloDto : EntityDto<int>
    {
        public string Descricao { get; set; }
        public string CategoriaFkDescricao { get; set; }
        public string FabricanteFkNome { get; set; }
    }
}
