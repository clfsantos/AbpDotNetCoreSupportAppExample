using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Crachas
{
    [Table("crachas_suprimentos_consumo")]
    public class SuprimentoConsumo : Entity<int>
    {
        [Required]
        [Column("data_compra", TypeName = "timestamp")]
        public virtual DateTime DataCompra { get; set; }

        [Required]
        [Column("suprimento_id", TypeName = "integer")]
        public virtual int SuprimentoId { get; set; }

        [Required]
        [Column("quantidade", TypeName = "integer")]
        public virtual int Quantidade { get; set; }

        [Required]
        [Column("valor", TypeName = "numeric(15,2)")]
        public virtual decimal Valor { get; set; }

        [Column("observacoes", TypeName = "text")]
        public virtual string Observacoes { get; set; }


        [ForeignKey("SuprimentoId")]
        public Suprimento SuprimentoFk { get; set; }
    }
}
