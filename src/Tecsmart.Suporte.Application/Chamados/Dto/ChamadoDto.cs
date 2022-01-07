using Abp.Application.Services.Dto;
using System;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class ChamadoDto : EntityDto<int>
    {
        public DateTime DataAbertura { get; set; }
        public string Ocorrencia { get; set; }
        public string ClienteFkNomeFantasia { get; set; }
        public string Contato { get; set; }
        public string ProdutoFkDescricao { get; set; }
        public string GrupoFkDescricao { get; set; }
        public string SubGrupoFkDescricao { get; set; }
        public string OrigemFkDescricao { get; set; }
        public string ClassificacaoFkDescricao { get; set; }
        public string ResponsavelFkName { get; set; }
        public string ResponsavelAtualFkName { get; set; }
        public string ResponsavelFechamentoFkName { get; set; }
        public DateTime? DataEncerramento { get; set; }
        public string ParecerFinal { get; set; }
        public string ReleaseFkVersao { get; set; }
        public bool GerouFinanceiro { get; set; }
        public int? OsRelacionada { get; set; }
        public int Status { get; set; }
    }
}
