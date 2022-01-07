using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Crachas.Dto
{
    public class CreateOrEditCrachaDto : EntityDto<int?>, IShouldNormalize
    {
        [DisplayName("Data Pedido")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public DateTime DataPedido { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? ClienteId { get; set; }

        [DisplayName("Contato")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Contato { get; set; }

        [DisplayName("Qtd. Pedido")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int QtdPedida { get; set; }

        [DisplayName("Tipo do Cart�o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? TipoCartao { get; set; }

        [DisplayName("Impress�o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? TipoImpressao { get; set; }

        [DisplayName("Observa��es do Pedido")]
        public string ObservacaoPedido { get; set; }

        [DisplayName("Qtd. Impressa")]
        public int? QtdImpressa { get; set; }

        [DisplayName("Status")]
        public int? Status { get; set; }

        [DisplayName("Data Finaliza��o")]
        public DateTime? DataTermino { get; set; }

        [DisplayName("Qtd. Perdida")]
        public int? QtdPerdida { get; set; }

        [DisplayName("Observa��es da Execu��o")]
        public string ObservacaoExecucao { get; set; }

        [DisplayName("Impressora")]
        public int? Impressora { get; set; }

        public void Normalize()
        {
            if(!Status.HasValue)
            {
                Status = 1;
            }

            if (!Impressora.HasValue)
            {
                Impressora = 3;
            }
        }
    }
}
