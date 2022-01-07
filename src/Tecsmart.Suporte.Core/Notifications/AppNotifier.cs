using Abp;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Notifications;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tecsmart.Suporte.Authorization.Users;

namespace Tecsmart.Suporte.Notifications
{
    public class AppNotifier : DomainService, IAppNotifier
    {
        private readonly INotificationPublisher _notificationPublisher;
        private readonly IRepository<User, long> _userRepository;

        public AppNotifier(INotificationPublisher notificationPublisher, IRepository<User, long> userRepository)
        {
            _notificationPublisher = notificationPublisher;
            _userRepository = userRepository;
        }

        public async Task WelcomeToTheApplicationAsync(User user)
        {
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.WelcomeToTheApplication,
                new MessageNotificationData(L("WelcomeToTheApplicationNotificationMessage")),
                severity: NotificationSeverity.Success,
                userIds: new[] {user.ToUserIdentifier()}
            );
        }

        public async Task SendMessageAsync(UserIdentifier user, string message, string url, NotificationSeverity severity = NotificationSeverity.Info)
        {
            var notificationData = new MessageNotificationData(message);
            notificationData.Properties.Add("Url", url);
            await _notificationPublisher.PublishAsync(
                AppNotificationNames.SimpleMessage,
                notificationData,
                severity: severity,
                userIds: new[] {user}
            );
        }

        public async Task SendMessageAllAsync(string message, string url, NotificationSeverity severity = NotificationSeverity.Info)
        {
            var filteredUsers = _userRepository.GetAll().Where(p => p.IsActive == true).ToArray();
            foreach (var item in filteredUsers)
            {
                await SendMessageAsync(new UserIdentifier(1, item.Id), message, url, severity);
            }
        }

    }
}
