using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Produtos
{
    [Table("spchamado_grupo")]
    public class Grupo : Entity<int>
    {
        [Required]
        [Column("spchamado_grupo_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

    }
}
