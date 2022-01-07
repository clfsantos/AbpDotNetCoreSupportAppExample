using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Chamados.Dto
{
    public class CreateOrEditTarefaDto : EntityDto<int?>, IShouldNormalize
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ChamadoId { get; set; }

        [DisplayName("Concluir tarefa")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Status { get; set; }

        [DisplayName("Duração")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public TimeSpan Duracao { get; set; }

        [DisplayName("Data")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataTarefa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataVencimento { get; set; }

        [DisplayName("Título")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long UsuarioId { get; set; }

        [DisplayName("Atribuir para")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long? UsuarioAtribuidoId { get; set; }

        [DisplayName("Cancelada")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Cancelada { get; set; }

        [DisplayName("Transferir Chamado")]
        public bool TransferirChamado { get; set; }

        public void Normalize()
        {
            if(!Id.HasValue)
            {
                Status = false;
                Cancelada = false;
            }

            DataVencimento = DataTarefa.Add(Duracao);
        }
    }
}
