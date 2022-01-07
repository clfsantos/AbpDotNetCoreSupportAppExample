using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Equipamentos.CategoriasProblemas
{
    [Table("problemamanutencao")]
    public class CategoriaProblema : Entity<int>
    {
        [Required]
        [Column("descricao_problema", TypeName = "citext")]
        public virtual string Descricao { get; set; }
    }
}
