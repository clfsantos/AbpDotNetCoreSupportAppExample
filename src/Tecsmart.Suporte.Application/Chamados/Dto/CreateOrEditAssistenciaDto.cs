using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditAssistenciaDto : EntityDto<int?>
    {
        [Required]
        public int ChamadoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Equipamento")]
        public int? EquipamentoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Categoria do Problema")]
        public int? CategoriaId { get; set; }

        [DisplayName("Dados Adicionais")]
        public string DadosAdicionais { get; set; }
    }
}
