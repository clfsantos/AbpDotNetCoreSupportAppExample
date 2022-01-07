using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Equipamentos.Categorias.Dto
{
    public class CategoriaDto : EntityDto<int>
    {
        public string Descricao { get; set; }
    }
}
