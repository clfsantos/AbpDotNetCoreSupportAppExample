using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Produtos.Dto
{
    public class SubGrupoDto : EntityDto<int>
    {
        public string Descricao { get; set; }
       
    }
}
