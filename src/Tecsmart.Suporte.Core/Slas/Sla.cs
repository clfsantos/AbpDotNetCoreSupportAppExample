using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Slas
{
    [Table("spchamado_sla")]
    public class Sla : Entity<int>
    {
        [Required]
        [Column("spchamado_sla_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

        [Column("spchamado_sla_time", TypeName = "interval")]
        public virtual TimeSpan? Duracao { get; set; }

    }
}
