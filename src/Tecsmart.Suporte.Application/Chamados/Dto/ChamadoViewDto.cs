using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class ChamadoViewDto : EntityDto<int>
    {
        public DateTime DataAbertura { get; set; }
        public string Ocorrencia { get; set; }
        public string ClienteFkNomeFantasia { get; set; }
        public string ResponsavelAtualFkName { get; set; }
        public int Status { get; set; }
        public bool TemAnexo { get; set; }
    }
}
