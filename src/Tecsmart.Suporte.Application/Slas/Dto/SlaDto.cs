using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Slas.Dto
{
    public class SlaDto : EntityDto<int>
    {
        public string Descricao { get; set; }
        public TimeSpan? Duracao { get; set; }
    }
}
