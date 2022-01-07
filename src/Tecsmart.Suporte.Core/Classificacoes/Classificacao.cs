using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Classificacoes
{
    [Table("spchamado_class")]
    public class Classificacao : Entity<int>
    {
        [Required]
        [Column("spchamado_class_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }

        [Column("spchamado_class_obs", TypeName = "varchar(255)")]
        public virtual string Observacao { get; set; }

    }
}
