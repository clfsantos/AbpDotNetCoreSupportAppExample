using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class ChamadoFollowupDto : EntityDto<int>
    {
        public int ChamadoId { get; set; }
        public DateTime FollowupFkDataFollowup { get; set; }
        public int FollowupFkTipo { get; set; }
        public string FollowupFkConteudo { get; set; }
        public string FollowupFkUsuarioFkFullName { get; set; }
        public long FollowupFkUsuarioId { get; set; }
        public string FollowupFkUsuarioTransferenciaFkFullName { get; set; }
        public bool FollowupFkCancelado { get; set; }
        public string FollowupFkEventoFkDescricao { get; set; }

    }
}
