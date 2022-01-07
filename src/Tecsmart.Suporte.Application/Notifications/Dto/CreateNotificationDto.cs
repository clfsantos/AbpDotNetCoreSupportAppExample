using Abp.Application.Services.Dto;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tecsmart.Suporte.Notifications.Dto
{
    public class CreateNotificationDto : EntityDto<int?>
    {
        [DisplayName("Notifica��o")]
        [Required(ErrorMessage = "O campo {0} � obrigat�rio")]
        public string Notificacao { get; set; }

        [DisplayName("Usu�rio a ser notificado")]
        public long? UsuarioId { get; set; }

        [DisplayName("Enviar para todos os usu�rios")]
        public bool EnviarTodosUsuarios { get; set; }
    }
}
