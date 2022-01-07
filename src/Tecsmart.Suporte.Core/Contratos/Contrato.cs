using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Contratos
{
    [Table("contrato")]
    public class Contrato : Entity<long>
    {
        [Required]
        [Column("contrato_cod_cliente", TypeName = "bigint")]
        public virtual long NumeroERP { get; set; }

        [Required]
        [Column("contrato_desc", TypeName = "varchar(512)")]
        public virtual string Descricao { get; set; }

        [Column("contrato_qtd", TypeName = "integer")]
        public virtual int Quantidade { get; set; }
    }
}
