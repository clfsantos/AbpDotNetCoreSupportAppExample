using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Notifications.Dto
{
    public class CreateNotificationDto : EntityDto<int?>
    {
        [DisplayName("Notificação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Notificacao { get; set; }

        [DisplayName("Usuário a ser notificado")]
        public long? UsuarioId { get; set; }

        [DisplayName("Enviar para todos os usuários")]
        public bool EnviarTodosUsuarios { get; set; }
    }
}
