using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Releases.Dto
{
    public class ReleaseDto : EntityDto<int>
    {
        public DateTime DataRelease { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoFkDescricao { get; set; }
        public string Versao { get; set; }
        public string Descricao { get; set; }
    }
}
