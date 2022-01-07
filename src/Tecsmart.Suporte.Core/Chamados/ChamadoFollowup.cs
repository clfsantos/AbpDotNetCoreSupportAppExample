using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spchamado_followup")]
    public class ChamadoFollowup : Entity<int>
    {
        [Required]
        [Column("spfollowup_id", TypeName = "integer")]
        public override int Id { get; set; }

        [Required]
        [Column("spchamado_id", TypeName = "integer")]
        public virtual int ChamadoId { get; set; }


        [ForeignKey("ChamadoId")]
        public Chamado ChamadoFk { get; set; }

        [ForeignKey("Id")]
        public Followup FollowupFk { get; set; }

    }
}
