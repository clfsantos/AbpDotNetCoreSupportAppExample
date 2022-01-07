using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Equipamentos.Fabricantes
{
    [Table("fabricante")]
    public class Fabricante : Entity<int>
    {
        [Required]
        [Column("nome_fabricante", TypeName = "citext")]
        public virtual string Nome { get; set; }
    }
}
