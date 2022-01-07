using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Crachas.Dto
{
    public class CrachaDto : EntityDto<int>
    {
        public DateTime DataPedido { get; set; }
        public string ClienteFkNomeFantasia { get; set; }
        public string Contato { get; set; }
        public int QtdPedida { get; set; }
        public int TipoCartao { get; set; }
        public int TipoImpressao { get; set; }
        public string ObservacaoPedido { get; set; }
        public int? QtdImpressa { get; set; }
        public int? Status { get; set; }
        public DateTime? DataTermino { get; set; }
        public int? QtdPerdida { get; set; }
        public string ObservacaoExecucao { get; set; }

        [NotMapped]
        public double PorcentagemPerdido
        {
            get
            {
                if (QtdPerdida > 0 && QtdImpressa > 0)
                {
                    return Math.Round(((double)QtdPerdida / (double)QtdImpressa) * 100, 2);
                }
                else
                {
                    return 0;
                }

            }
        }

        [NotMapped]
        public int Pendentes
        {
            get
            {
                if (QtdImpressa.HasValue)
                {
                    QtdImpressa = QtdImpressa;
                }
                else
                {
                    QtdImpressa = 0;
                }
                return QtdPedida - (int)QtdImpressa;
            }
        }

    }
}
