using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Clientes;
using Tecsmart.Suporte.Equipamentos.Modelos;

namespace Tecsmart.Suporte.Equipamentos
{
    [Table("equipamento")]
    public class Equipamento : Entity<int>
    {
        [Required]
        [Column("nr_serie", TypeName = "varchar(17)")]
        public virtual string Descricao { get; set; }

        [Required]
        [Column("crcliente_id", TypeName = "integer")]
        public virtual int ClienteId { get; set; }

        [Required]
        [Column("id_modelo", TypeName = "integer")]
        public virtual int ModeloId { get; set; }

        [Required]
        [Column("teste_ok", TypeName = "boolean")]
        public virtual bool TesteOk { get; set; }

        [Required]
        [Column("inativo", TypeName = "boolean")]
        public virtual bool Inativo { get; set; }

        [Column("dt_inclusao", TypeName = "timestamp")]
        public virtual DateTime? DataInclusao { get; set; }


        [ForeignKey("ClienteId")]
        public Cliente ClienteFK { get; set; }

        [ForeignKey("ModeloId")]
        public Modelo ModeloFK { get; set; }
    }
}
