using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Suprimentos.Dto
{
    public class SuprimentoConsumoDto : EntityDto<int>
    {
        public DateTime DataCompra { get; set; }

        public string SuprimentoFkDescricao { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

        public string Observacoes { get; set; }

    }
}
