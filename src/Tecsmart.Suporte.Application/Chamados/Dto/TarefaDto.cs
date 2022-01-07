using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class TarefaDto : EntityDto<int>
    {
        public int ChamadoId { get; set; }
        public DateTime DataTarefa { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Descricao { get; set; }
        public string UsuarioAtribuidoFkFullName { get; set; }
        public string ChamadoFkClienteFkNomeFantasia { get; set; }
        public bool Status { get; set; }
        public bool Cancelada { get; set; }
        public int StatusId { get; set; }
    }
}
