using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.FilaAtendimentos.Dto
{
    public class FilaRetornoDto : EntityDto<int>
    {
        public int FilaAtendimentoId { get; set; }
        public DateTime DataRetorno { get; set; }
        public int TipoRetorno { get; set; }
        public string Observacao { get; set; }
        public long UsuarioId { get; set; }
        public string UsuarioFkFullName { get; set; }
    }
}
