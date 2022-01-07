using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Chamados
{
    public class EtapaView : Entity<int>
    {
        [Column("spchamado_id", TypeName = "integer")]
        public virtual int ChamadoId { get; set; }

        [Column("etapa_dt", TypeName = "timestamp")]
        public virtual DateTime DataEtapa { get; set; }

        [Column("etapa_desc", TypeName = "varchar(256)")]
        public virtual string EtapaDescricao { get; set; }

        [Column("crcliente_fantasia", TypeName = "varchar(255)")]
        public virtual string ClienteFantasia { get; set; }

        [Column("etapa_responsavel", TypeName = "integer")]
        public virtual long ResponsavelAtualId { get; set; }

        [Column("etapa_resp", TypeName = "integer")]
        public virtual long ResponsavelEtapaId { get; set; }

        [Column("setor_responsavel", TypeName = "varchar")]
        public virtual string SetorResponsavel { get; set; }

        [Column("etapa_status_desc", TypeName = "varchar(60)")]
        public virtual string StatusDescricao { get; set; }

        [Column("etapa_imp_hrs", TypeName = "double precision")]
        public virtual double EtapaHorasCorridas { get; set; }

        [Column("etapa_imp_hrs_sla", TypeName = "boolean")]
        public virtual bool SlaVencido { get; set; }

        [Column("hrs_sla", TypeName = "integer")]
        public virtual int SlaPrevisto { get; set; }


        [ForeignKey("ResponsavelAtualId")]
        public User ResponsavelAtualFk { get; set; }

        [ForeignKey("ResponsavelEtapaId")]
        public User ResponsavelEtapaFk { get; set; }

    }
}
