using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class PrioridadeFluxoViewDto : EntityDto<int>
    {
        public string UsuarioFkName { get; set; }
        public DateTime UltimoAtendimento { get; set; }
        public bool StatusRamal { get; set; }
    }
}
