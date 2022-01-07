using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Authorization.Users;
using Tecsmart.Suporte.Classificacoes;
using Tecsmart.Suporte.Clientes;
using Tecsmart.Suporte.Origens;
using Tecsmart.Suporte.Produtos;
using Tecsmart.Suporte.Releases;

namespace Tecsmart.Suporte.Chamados
{
    [Table("spchamado")]
    public class Chamado : Entity<int>
    {
        [Required]
        [Column("spchamado_dt_abertura", TypeName = "timestamp")]
        public virtual DateTime DataAbertura { get; set; }

        [Required]
        [Column("spchamado_cliente_id", TypeName = "integer")]
        public virtual int ClienteId { get; set; }

        [Required]
        [Column("spchamado_contato", TypeName = "varchar(60)")]
        public virtual string Contato { get; set; }

        [Required]
        [Column("spchamado_financeiro", TypeName = "boolean")]
        public virtual bool GerouFinanceiro { get; set; }

        [Column("spchamado_osrel", TypeName = "integer")]
        public virtual int? OsRelacionada { get; set; }

        [Required]
        [Column("spchamado_origem_id", TypeName = "integer")]
        public virtual int OrigemId { get; set; }

        [Required]
        [Column("spchamado_class_id", TypeName = "integer")]
        public virtual int ClassificacaoId { get; set; }

        [Required]
        [Column("spchamado_produto_id", TypeName = "integer")]
        public virtual int ProdutoId { get; set; }

        [Column("spchamado_grupo_id", TypeName = "integer")]
        public virtual int? GrupoId { get; set; }

        [Column("spchamado_subgrupo_id", TypeName = "integer")]
        public virtual int? SubGrupoId { get; set; }

        [Required]
        [Column("spchamado_ocorrencia", TypeName = "text")]
        public virtual string Ocorrencia { get; set; }

        [Required]
        [Column("spchamado_responsavel_id", TypeName = "integer")]
        public virtual long ResponsavelId { get; set; }

        [Required]
        [Column("spchamado_resp_atual_id", TypeName = "integer")]
        public virtual long ResponsavelAtualId { get; set; }

        [Required]
        [Column("spchamado_sla_prioridade_id", TypeName = "integer")]
        public virtual int SlaPrioridadeId { get; set; }

        [Required]
        [Column("spchamado_sla_data_vto", TypeName = "timestamp")]
        public virtual DateTime SlaDataVencimento { get; set; }

        [Column("spchamado_dt_encerramento", TypeName = "timestamp")]
        public virtual DateTime? DataEncerramento { get; set; }

        [Column("spchamado_status", TypeName = "integer")]
        public virtual int? Status { get; set; }

        [Column("spchamado_resp_fechamento_id", TypeName = "integer")]
        public virtual long? ResponsavelFechamentoId { get; set; }

        [Column("spchamado_release_id", TypeName = "integer")]
        public virtual int? ReleaseId { get; set; }

        [Column("spchamado_resolver", TypeName = "text")]
        public virtual string ParecerFinal { get; set; }

        [Column("spchamado_aberto", TypeName = "boolean")]
        public virtual bool ChamadoAberto { get; set; }

        [Column("spchamado_cancelado", TypeName = "boolean")]
        public virtual bool ChamadoCancelado { get; set; }


        [ForeignKey("ClienteId")]
        public Cliente ClienteFk { get; set; }

        [ForeignKey("ClassificacaoId")]
        public Classificacao ClassificacaoFk { get; set; }

        [ForeignKey("OrigemId")]
        public Origem OrigemFk { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto ProdutoFk { get; set; }

        [ForeignKey("GrupoId")]
        public Grupo GrupoFk { get; set; }

        [ForeignKey("SubGrupoId")]
        public SubGrupo SubGrupoFk { get; set; }

        [ForeignKey("ResponsavelId")]
        public User ResponsavelFk { get; set; }

        [ForeignKey("ResponsavelAtualId")]
        public User ResponsavelAtualFk { get; set; }

        [ForeignKey("ResponsavelFechamentoId")]
        public User ResponsavelFechamentoFk { get; set; }

        [ForeignKey("ReleaseId")]
        public Release ReleaseFk { get; set; }

    }
}
