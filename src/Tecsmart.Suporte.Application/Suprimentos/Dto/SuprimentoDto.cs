using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Suprimentos.Dto
{
    public class SuprimentoDto : EntityDto<int>
    {
        public string Descricao { get; set; }
    }
}
