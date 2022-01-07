using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Produtos
{
    [Table("spchamado_grupo_subgrupo")]
    public class GrupoSubGrupo : Entity<int>
    {
        [Required]
        [Column("spchamado_subgrupo_id", TypeName = "integer")]
        public override int Id { get; set; }

        [Required]
        [Column("spchamado_grupo_id", TypeName = "integer")]
        public virtual int GrupoId { get; set; }


        [ForeignKey("Id")]
        public SubGrupo SubGrupoFk { get; set; }

        [ForeignKey("GrupoId")]
        public Grupo GrupoFk { get; set; }

    }
}
