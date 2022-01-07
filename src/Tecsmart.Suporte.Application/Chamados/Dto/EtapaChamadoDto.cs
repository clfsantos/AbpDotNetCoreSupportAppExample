using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class EtapaChamadoDto : EntityDto<int>
    {
        public int ChamadoId { get; set; }
        public string ChamadoFkClienteFkNomeFantasia { get; set; }
        public int EtapaStatusId { get; set; }
        public int EtapaFkSequencia { get; set; }
        public DateTime DataEtapa { get; set; }
        public string EtapaFkDescricao { get; set; }
        public string Observacao { get; set; }
        public string EtapaFkResponsavelFkFullName { get; set; }
        public string EtapaStatusFkDescricao { get; set; }
    }
}
