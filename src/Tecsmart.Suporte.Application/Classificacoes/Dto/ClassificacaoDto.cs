using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Classificacoes.Dto
{
    public class ClassificacaoDto : EntityDto<int>
    {
        public string Descricao { get; set; }
        public string Observacao { get; set; }
    }
}
