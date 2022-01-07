using Tecsmart.Suporte.Chamados.Dto;

namespace Tecsmart.Suporte.Web.Models.Chamados
{
    public class CreateOrEditTarefaViewModel
    {
        public CreateOrEditTarefaDto Tarefa { get; set; }
        public bool IsEditMode => Tarefa.Id.HasValue;

    }
}
