using Abp.Application.Services.Dto;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditChamadoDto : EntityDto<int?>
    {
        [DisplayName("Abertura")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public DateTime DataAbertura { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? ClienteId { get; set; }

        [DisplayName("Contato")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Contato { get; set; }

        [DisplayName("Gerou Financeiro")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public bool GerouFinanceiro { get; set; }

        [DisplayName("O.S. Relacionada")]
        public int? OsRelacionada { get; set; }

        [DisplayName("Origem")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int OrigemId { get; set; }

        [DisplayName("Classifica��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int ClassificacaoId { get; set; }

        [DisplayName("Produto")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int? ProdutoId { get; set; }

        [DisplayName("Grupo")]
        public int? GrupoId { get; set; }

        [DisplayName("Sub-Grupo")]
        public int? SubGrupoId { get; set; }

        [DisplayName("Ocorr�ncia")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Ocorrencia { get; set; }

        [DisplayName("Aberto por")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int ResponsavelId { get; set; }

        [DisplayName("Respons�vel Atual")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int ResponsavelAtualId { get; set; }

        [DisplayName("SLA")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public int SlaPrioridadeId { get; set; }

        [DisplayName("Vencimento SLA")]
        public DateTime? SlaDataVencimento { get; set; }

        [DisplayName("Data Encerramento")]
        public DateTime? DataEncerramento { get; set; }

        [DisplayName("Status")]
        public int? Status { get; set; }

        [DisplayName("Fechado por")]
        public int? ResponsavelFechamentoId { get; set; }

        [DisplayName("Release")]
        public int? ReleaseId { get; set; }

        [DisplayName("Parecer final")]
        public string ParecerFinal { get; set; }

        public bool ChamadoAberto { get; set; }
        public bool ChamadoCancelado { get; set; }

        [DisplayName("Finalizar Chamado")]
        [NotMapped]
        public bool FinalizarChamado { get; set; }

    }
}
