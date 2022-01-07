using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Eventos
{
    [Table("eventofollowup")]
    public class Evento : Entity<int>
    {
        [Required]
        [Column("descricao_evento", TypeName = "citext")]
        public virtual string Descricao { get; set; }

        [Column("prioridade_id", TypeName = "integer")]
        public virtual int PrioridadeId { get; set; }

    }
}
