using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.FilaAtendimentos
{
    [Table("spchamado_fila_retornos")]
    public class FilaRetorno : Entity<int>
    {
        [Required]
        public virtual int FilaAtendimentoId { get; set; }

        public virtual int TipoRetorno { get; set; }

        public virtual DateTime DataRetorno { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public virtual string Observacao { get; set; }

        [Column(TypeName = "integer")]
        public virtual long UsuarioId { get; set; }


        [ForeignKey("FilaAtendimentoId")]
        public FilaAtendimento FilaAtendimentoFk { get; set; }

        [ForeignKey("UsuarioId")]
        public User UsuarioFk { get; set; }

    }
}
