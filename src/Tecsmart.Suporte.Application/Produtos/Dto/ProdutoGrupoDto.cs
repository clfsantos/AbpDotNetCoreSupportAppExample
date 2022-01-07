using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Produtos.Dto
{
    public class ProdutoGrupoDto : EntityDto<int>
    {
        public int ProdutoId { get; set; }
        public string GrupoFkDescricao { get; set; }

    }
}
