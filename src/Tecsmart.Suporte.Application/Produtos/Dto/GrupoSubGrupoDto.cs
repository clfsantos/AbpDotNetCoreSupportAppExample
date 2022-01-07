using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Produtos.Dto
{
    public class GrupoSubGrupoDto : EntityDto<int>
    {
        public int GrupoId { get; set; }
        public string SubGrupoFkDescricao { get; set; }

    }
}
