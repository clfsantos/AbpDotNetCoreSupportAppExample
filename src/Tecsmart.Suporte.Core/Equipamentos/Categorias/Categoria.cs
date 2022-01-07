using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Equipamentos.Categorias
{
    [Table("categoria")]
    public class Categoria : Entity<int>
    {
        [Required]
        [Column("descricao_categoria", TypeName = "citext")]
        public virtual string Descricao { get; set; }
    }
}
