using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Clidades
{
    [Table("cidade")]
    public class Cidade : Entity<int>
    {
        [Required]
        [Column("nome", TypeName = "citext")]
        public virtual string Nome { get; set; }

        [Required]
        [Column("codigo_ibge", TypeName = "integer")]
        public virtual int CodigoIBGE { get; set; }

        [Required]
        [Column("estado_id", TypeName = "integer")]
        public virtual int EstadoId { get; set; }
    }
}
