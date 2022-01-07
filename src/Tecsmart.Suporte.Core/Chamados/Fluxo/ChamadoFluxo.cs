using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;
using Tecsmart.Suporte.Clientes;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spchamado_fluxo")]
    public class ChamadoFluxo : Entity<int>
    {
        [Required]
        [Column("usuario_id", TypeName = "integer")]
        public virtual long UsuarioId { get; set; }

        [Required]
        [Column("crcliente_id", TypeName = "integer")]
        public virtual int ClienteId { get; set; }

        [Required]
        [Column("spchamado_fluxo_dt", TypeName = "timestamp")]
        public virtual DateTime DataFluxo { get; set; }


        [ForeignKey("UsuarioId")]
        public User UsuarioFk { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente ClienteFk { get; set; }

    }
}
