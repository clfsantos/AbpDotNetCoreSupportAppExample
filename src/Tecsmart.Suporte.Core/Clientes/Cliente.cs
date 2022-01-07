using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Clidades;

namespace Tecsmart.Suporte.Clientes
{
    [Table("crcliente")]
    public class Cliente : Entity<int>
    {
        [Column("crcliente_cnpj", TypeName = "varchar(14)")]
        public virtual string CpfCnpj { get; set; }

        [Column("crcliente_fantasia", TypeName = "varchar(256)")]
        public virtual string NomeFantasia { get; set; }

        [Column("crcliente_razao", TypeName = "varchar(256)")]
        public virtual string RazaoSocial { get; set; }

        [Column("crcliente_bloqueado", TypeName = "boolean")]
        public virtual bool IsClienteBloqueado { get; set; }

        [Column("crcliente_nerp", TypeName = "bigint")]
        public virtual long? NumeroERP { get; set; }

        [Column("crcliente_cidade_id", TypeName = "integer")]
        public virtual int CidadeId { get; set; }

        [Column("crcliente_email", TypeName = "varchar(255)")]
        public virtual string Email { get; set; }

        [Column("crcliente_end_rua", TypeName = "varchar(255)")]
        public virtual string EnderecoRua { get; set; }

        [Column("crcliente_end_num", TypeName = "integer")]
        public virtual int? EnderecoNumero { get; set; }

        [Column("crcliente_end_bairo", TypeName = "varchar(60)")]
        public virtual string EnderecoBairro { get; set; }

        [Column("crcliente_end_complemento", TypeName = "varchar(60)")]
        public virtual string EnderecoComplemento { get; set; }

        [Column("crcliente_end_cep", TypeName = "varchar(8)")]
        public virtual string EnderecoCep { get; set; }

        [Column("crcliente_telefone", TypeName = "varchar(11)")]
        public virtual string Telefone { get; set; }

        [Column("crcliente_contato", TypeName = "varchar(120)")]
        public virtual string Contato { get; set; }

        [Column("rcliente_celular", TypeName = "varchar(11)")]
        public virtual string CelularRh { get; set; }

        [Column("crcliente_email_rh", TypeName = "varchar(255)")]
        public virtual string EmailRh { get; set; }

        [Column("crcliente_up_mail_or_cel", TypeName = "timestamp")]
        public virtual DateTime? DataUpdateEmailOrCel { get; set; }

        [Column("crcliente_obs", TypeName = "text")]
        public virtual string ClienteObs { get; set; }


        [ForeignKey("CidadeId")]
        public Cidade CidadeFk { get; set; }
    }
}
