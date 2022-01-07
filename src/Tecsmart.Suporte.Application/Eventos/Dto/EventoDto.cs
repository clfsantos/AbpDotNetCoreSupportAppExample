using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Eventos.Dto
{
    public class EventoDto : EntityDto<int>
    {
        public string Descricao { get; set; }
        public int? PrioridadeId { get; set; }
    }
}
