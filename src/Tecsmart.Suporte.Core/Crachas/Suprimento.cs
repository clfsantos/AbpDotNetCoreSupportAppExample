using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Crachas
{
    [Table("crachas_suprimentos")]
    public class Suprimento : Entity<int>
    {
        [Required]
        [Column("descricao", TypeName = "varchar(512)")]
        public virtual string Descricao { get; set; }

    }
}
