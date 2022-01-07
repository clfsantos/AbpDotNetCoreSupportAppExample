using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spimplantacao_etapa_status")]
    public class EtapaStatus : Entity<int>
    {
        [Required]
        [Column("etapa_status_desc", TypeName = "varchar(60)")]
        public virtual string Descricao { get; set; }
    }
}
