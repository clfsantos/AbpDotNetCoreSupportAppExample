using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Produtos
{
    [Table("spchamado_produto")]
    public class Produto : Entity<int>
    {
        [Required]
        [Column("spchamado_produto_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

    }
}
