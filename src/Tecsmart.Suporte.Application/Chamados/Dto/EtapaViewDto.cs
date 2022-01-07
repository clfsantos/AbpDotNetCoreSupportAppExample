using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class EtapaViewDto : EntityDto<int>
    {
        public int ChamadoId { get; set; }
        public DateTime DataEtapa { get; set; }
        public string EtapaDescricao { get; set; }
        public string ClienteFantasia { get; set; }
        public string ResponsavelAtualFkFullName { get; set; }
        public string ResponsavelEtapaFkFullName { get; set; }
        public string SetorResponsavel { get; set; }
        public string StatusDescricao { get; set; }
        public double EtapaHorasCorridas { get; set; }
        public bool SlaVencido { get; set; }
        public int SlaPrevisto { get; set; }

        public double DiasDecorridos
        {
            get
            {
                TimeSpan result = TimeSpan.FromHours(EtapaHorasCorridas);
                return Math.Round(result.TotalDays, 2);
            }
        }
    }
}
