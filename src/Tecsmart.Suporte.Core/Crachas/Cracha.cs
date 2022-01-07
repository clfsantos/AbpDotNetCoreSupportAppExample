using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecsmart.Suporte.Clientes;

namespace Tecsmart.Suporte.Crachas
{
    [Table("crachas")]
    public class Cracha : Entity<int>
    {
        [Required]
        public virtual DateTime DataPedido { get; set; }

        [Required]
        public virtual int ClienteId { get; set; }

        [Required]
        [Column(TypeName = "varchar(60)")]
        public virtual string Contato { get; set; }

        [Required]
        public virtual int QtdPedida { get; set; }

        [Required]
        public virtual int TipoCartao { get; set; }

        [Required]
        public virtual int TipoImpressao { get; set; }

        [Column(TypeName = "text")]
        public virtual string ObservacaoPedido { get; set; }

        public virtual int? QtdImpressa { get; set; }

        public virtual int? Status { get; set; }

        public virtual DateTime? DataTermino { get; set; }

        public virtual int? QtdPerdida { get; set; }

        [Column(TypeName = "text")]
        public virtual string ObservacaoExecucao { get; set; }

        public virtual int? Impressora { get; set; }


        [ForeignKey("ClienteId")]
        public Cliente ClienteFk { get; set; }
    }
}
