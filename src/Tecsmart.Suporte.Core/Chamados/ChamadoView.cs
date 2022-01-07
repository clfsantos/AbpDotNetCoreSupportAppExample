using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;
using Tecsmart.Suporte.Clientes;

namespace Tecsmart.Suporte.Chamados
{
    public class ChamadoView : Entity<int>
    {
        [Column("spchamado_dt_abertura", TypeName = "timestamp")]
        public virtual DateTime DataAbertura { get; set; }

        [Column("spchamado_cliente_id", TypeName = "integer")]
        public virtual int ClienteId { get; set; }

        [Column("spchamado_ocorrencia", TypeName = "text")]
        public virtual string Ocorrencia { get; set; }

        [Column("spchamado_status", TypeName = "integer")]
        public virtual int Status { get; set; }

        [Column("spchamado_resp_atual_id", TypeName = "integer")]
        public virtual long ResponsavelAtualId { get; set; }

        [Column("temanexo", TypeName = "boolean")]
        public virtual bool TemAnexo { get; set; }


        [ForeignKey("ClienteId")]
        public Cliente ClienteFk { get; set; }

        [ForeignKey("ResponsavelAtualId")]
        public User ResponsavelAtualFk { get; set; }
    }
}
