using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Chamados
{
    public class PrioridadeFluxoView : Entity<int>
    {
        [Column("contar_fluxo", TypeName = "integer")]
        public override int Id { get; set; }

        [Column("spchamado_usuario_prioridade_id", TypeName = "integer")]
        public virtual int PrioridadeId { get; set; }

        [Column("usuario_id", TypeName = "integer")]
        public virtual long UsuarioId { get; set; }

        [Column("ultimo_atendimento", TypeName = "timestamp")]
        public virtual DateTime UltimoAtendimento { get; set; }

        [Column("status", TypeName = "boolean")]
        public virtual bool StatusRamal { get; set; }


        [ForeignKey("UsuarioId")]
        public User UsuarioFk { get; set; }

    }
}
