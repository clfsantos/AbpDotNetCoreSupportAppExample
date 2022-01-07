using Abp;
using Abp.Notifications;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Notifications
{
    public interface IAppNotifier
    {
        Task WelcomeToTheApplicationAsync(User user);

        Task SendMessageAsync(UserIdentifier user, string message, string url, NotificationSeverity severity = NotificationSeverity.Info);

        Task SendMessageAllAsync(string message, string url, NotificationSeverity severity = NotificationSeverity.Info);
    }
}
