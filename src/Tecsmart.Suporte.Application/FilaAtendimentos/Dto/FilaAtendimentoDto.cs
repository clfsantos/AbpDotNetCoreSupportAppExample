using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.FilaAtendimentos.Dto
{
    public class FilaAtendimentoDto : EntityDto<int>
    {
        public DateTime? DataFila { get; set; }
        public string ClienteFkNomeFantasia { get; set; }
        public string Observacao { get; set; }
        public bool Atendido { get; set; }
        public int? QtdRetorno { get; set; }
        public bool Cancelado { get; set; }
    }
}
