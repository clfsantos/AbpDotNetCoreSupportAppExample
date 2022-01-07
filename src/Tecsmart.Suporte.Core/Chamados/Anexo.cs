using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spanexo")]
    public class Anexo : Entity<int>
    {
        [Required]
        [Column("spchamado_id", TypeName = "integer")]
        public virtual int ChamadoId { get; set; }

        [Required]
        [Column("spanexo_nome", TypeName = "varchar(255)")]
        public virtual string Nome { get; set; }

        [Required]
        [Column("spanexo_caminho", TypeName = "varchar(255)")]
        public virtual string Caminho { get; set; }

        [Required]
        [Column("spanexo_dt_up", TypeName = "timestamp")]
        public virtual DateTime DataUpload { get; set; }

        [Required]
        [Column("spanexo_usuario", TypeName = "integer")]
        public virtual long UsuarioId { get; set; }


        [ForeignKey("ChamadoId")]
        public Chamado ChamadoFk { get; set; }

        [ForeignKey("UsuarioId")]
        public User UsuarioFk { get; set; }

    }
}
