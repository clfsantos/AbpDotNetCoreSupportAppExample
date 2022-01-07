using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class AnexoDto : EntityDto<int>
    {
        public int ChamadoId { get; set; }
        public string Nome { get; set; }
        public string Caminho { get; set; }
        public DateTime DataUpload { get; set; }
        public long UsuarioId { get; set; }
        public string UsuarioFkFullName { get; set; }
    }
}
