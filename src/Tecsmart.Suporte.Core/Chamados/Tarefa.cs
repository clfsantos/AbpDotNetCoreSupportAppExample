using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Chamados
{
    [Table("sptarefa")]
    public class Tarefa : Entity<int>
    {
        [Required]
        [Column("spchamado_id", TypeName = "integer")]
        public virtual int ChamadoId { get; set; }

        [Required]
        [Column("sptarefa_status", TypeName = "boolean")]
        public virtual bool Status { get; set; }

        [Required]
        [Column("sptarefa_duracao", TypeName = "time")]
        public virtual TimeSpan Duracao { get; set; }

        [Required]
        [Column("sptarefa_dt_tarefa", TypeName = "timestamp")]
        public virtual DateTime DataTarefa { get; set; }

        [Required]
        [Column("sptarefa_dt_vto", TypeName = "timestamp")]
        public virtual DateTime DataVencimento { get; set; }

        [Required]
        [Column("sptarefa_titulo", TypeName = "varchar(60)")]
        public virtual string Titulo { get; set; }

        [Required]
        [Column("sptarefa_desc", TypeName = "text")]
        public virtual string Descricao { get; set; }

        [Required]
        [Column("sptarefa_usuario", TypeName = "integer")]
        public virtual long UsuarioId { get; set; }

        [Column("sptarefa_u_atribuido", TypeName = "integer")]
        public virtual long? UsuarioAtribuidoId { get; set; }

        [Required]
        [Column("sptarefa_cancelada", TypeName = "boolean")]
        public virtual bool Cancelada { get; set; }

        [Column("status", TypeName = "integer")]
        public virtual int StatusId { get; set; }


        [ForeignKey("ChamadoId")]
        public Chamado ChamadoFk { get; set; }

        [ForeignKey("UsuarioId")]
        public User UsuarioFk { get; set; }

        [ForeignKey("UsuarioAtribuidoId")]
        public User UsuarioAtribuidoFk { get; set; }

    }
}
