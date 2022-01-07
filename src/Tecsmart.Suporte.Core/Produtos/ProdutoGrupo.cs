using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Produtos
{
    [Table("spchamado_produto_grupo")]
    public class ProdutoGrupo : Entity<int>
    {
        [Required]
        [Column("spchamado_grupo_id", TypeName = "integer")]
        public override int Id { get; set; }

        [Required]
        [Column("spchamado_produto_id", TypeName = "integer")]
        public virtual int ProdutoId { get; set; }


        [ForeignKey("Id")]
        public Grupo GrupoFk { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto ProdutoFk { get; set; }

    }
}
