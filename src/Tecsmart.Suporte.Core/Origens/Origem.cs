using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Origens
{
    [Table("spchamado_origem")]
    public class Origem : Entity<int>
    {
        [Required]
        [Column("spchamado_origem_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

    }
}
