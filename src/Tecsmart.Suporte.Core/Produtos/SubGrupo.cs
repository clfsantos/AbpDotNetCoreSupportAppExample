using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Produtos
{
    [Table("spchamado_subgrupo")]
    public class SubGrupo : Entity<int>
    {
        [Required]
        [Column("spchamado_subgrupo_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

    }
}
