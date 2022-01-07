using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.Origens.Dto
{
    public class OrigemDto : EntityDto<int>
    {
        public string Descricao { get; set; }
    }
}
