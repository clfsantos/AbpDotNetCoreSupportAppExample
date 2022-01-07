using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class ChamadoFluxoDto : EntityDto<int>
    {
        public string UsuarioFkName { get; set; }
        public string ClienteFkNomeFantasia { get; set; }
        public DateTime DataFluxo { get; set; }
    }
}
