using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spimplantacao_etapa")]
    public class Etapa : Entity<int>
    {
        [Required]
        [Column("etapa_seq", TypeName = "integer")]
        public virtual int Sequencia { get; set; }

        [Required]
        [Column("etapa_desc", TypeName = "varchar(256)")]
        public virtual string Descricao { get; set; }

        [Required]
        [Column("etapa_resp", TypeName = "integer")]
        public virtual long ResponsavelId { get; set; }

        [Column("setor_resp", TypeName = "varchar(256)")]
        public virtual string SetorResponsavel { get; set; }

        [Column("etapa_obs", TypeName = "text")]
        public virtual string Observacao { get; set; }

        [Column("etapa_hrs", TypeName = "integer")]
        public virtual int HorasSla { get; set; }


        [ForeignKey("ResponsavelId")]
        public User ResponsavelFk { get; set; }
    }
}
