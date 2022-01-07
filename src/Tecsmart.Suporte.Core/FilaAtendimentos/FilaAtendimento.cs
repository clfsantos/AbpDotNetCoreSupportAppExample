using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Clientes;

namespace Tecsmart.Suporte.FilaAtendimentos
{
    [Table("spchamado_fila")]
    public class FilaAtendimento : Entity<int>
    {
        [Required]
        [Column("crcliente_id", TypeName = "integer")]
        public virtual int ClienteId { get; set; }

        [Column("spchamado_fila_obs", TypeName = "text")]
        public virtual string Observacao { get; set; }

        [Column("spchamado_fila_dt", TypeName = "timestamp")]
        public virtual DateTime? DataFila { get; set; }

        [Column("spchamado_fila_atendido", TypeName = "boolean")]
        public virtual bool Atendido { get; set; }

        [Column("spchamado_fila_qtd", TypeName = "integer")]
        public virtual int? QtdRetorno { get; set; }

        [Column("spchamado_fila_cancelado", TypeName = "boolean")]
        public virtual bool Cancelado { get; set; }


        [ForeignKey("ClienteId")]
        public Cliente ClienteFk { get; set; }

    }
}
