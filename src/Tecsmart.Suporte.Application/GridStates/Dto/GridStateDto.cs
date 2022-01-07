using Abp.Application.Services.Dto;

namespace Tecsmart.Suporte.GridStates.Dto
{
    public class GridStateDto : EntityDto<int>
    {
        public long UsuarioId { get; set; }
        public string Tela { get; set; }
        public string Descricao { get; set; }
        public string State { get; set; }
    }
}
