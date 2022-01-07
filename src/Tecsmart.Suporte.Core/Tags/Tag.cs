using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Tags
{
    [Table("tag")]
    public class Tag : Entity<int>
    {
        [Required]
        [Column("tag_descricao", TypeName = "varchar(256)")]
        public virtual string Descricao { get; set; }
    }
}
