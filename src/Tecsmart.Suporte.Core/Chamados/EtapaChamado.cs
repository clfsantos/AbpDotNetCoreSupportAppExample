using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spimplantacao_etapa_chamado")]
    public class EtapaChamado : Entity<int>
    {
        [Required]
        [Column("spchamado_id", TypeName = "integer")]
        public virtual int ChamadoId { get; set; }

        [Required]
        [Column("etapa_id", TypeName = "integer")]
        public virtual int EtapaId { get; set; }

        [Required]
        [Column("etapa_status_id", TypeName = "integer")]
        public virtual int EtapaStatusId { get; set; }

        [Column("etapa_obs", TypeName = "text")]
        public virtual string Observacao { get; set; }

        [Column("etapa_dt", TypeName = "timestamp")]
        public virtual DateTime? DataEtapa { get; set; }

        [Column("etapa_dt_conclusao", TypeName = "timestamp")]
        public virtual DateTime? DataConclusao { get; set; }

        [Column("etapa_obs_recusada", TypeName = "text")]
        public virtual string ObsRecusada { get; set; }

        [Column("etapa_dt_recusada", TypeName = "timestamp")]
        public virtual DateTime? DataRecusada { get; set; }


        [ForeignKey("ChamadoId")]
        public Chamado ChamadoFk { get; set; }

        [ForeignKey("EtapaId")]
        public Etapa EtapaFk { get; set; }

        [ForeignKey("EtapaStatusId")]
        public EtapaStatus EtapaStatusFk { get; set; }

    }
}
