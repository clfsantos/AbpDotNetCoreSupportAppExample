using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.CategoriasProblemas.Dto
{
    public class CategoriaProblemaDto : EntityDto<int>
    {
        public string Descricao { get; set; }
    }
}
