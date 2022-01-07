using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;
using Tecsmart.Suporte.Eventos;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spfollowup")]
    public class Followup : Entity<int>
    {
        [Required]
        [Column("spfollowup_tipo", TypeName = "integer")]
        public virtual int Tipo { get; set; }

        [Required]
        [Column("spfollowup_dt", TypeName = "timestamp")]
        public virtual DateTime DataFollowup { get; set; }

        [Required]
        [Column("spfollowup_conteudo", TypeName = "text")]
        public virtual string Conteudo { get; set; }

        [Required]
        [Column("spfollowup_usuario_id", TypeName = "integer")]
        public virtual long UsuarioId { get; set; }

        [Column("spfollowup_usuario_trans", TypeName = "integer")]
        public virtual long? UsuarioTransferenciaId { get; set; }

        [Required]
        [Column("cancelado", TypeName = "boolean")]
        public virtual bool Cancelado { get; set; }

        [Column("eventofollowup_id", TypeName = "integer")]
        public virtual int? EventoFollowupId { get; set; }


        [ForeignKey("UsuarioId")]
        public User UsuarioFk { get; set; }

        [ForeignKey("UsuarioTransferenciaId")]
        public User UsuarioTransferenciaFk { get; set; }

        [ForeignKey("EventoFollowupId")]
        public Evento EventoFk { get; set; }

    }
}
