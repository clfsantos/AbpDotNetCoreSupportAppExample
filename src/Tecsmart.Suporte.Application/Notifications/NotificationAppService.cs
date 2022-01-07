using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.UI;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Tecsmart.Suporte.Authorization;
using Tecsmart.Suporte.Notifications.Dto;

namespace Tecsmart.Suporte.Notifications
{
    [AbpAuthorize]
    public class NotificationAppService : SuporteAppServiceBase, INotificationAppService
    {
        private readonly INotificationDefinitionManager _notificationDefinitionManager;
        private readonly IUserNotificationManager _userNotificationManager;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly IRepository<TenantNotificationInfo, Guid> _tenantNotificationRepository;
        private readonly IRepository<UserNotificationInfo, Guid> _userNotificationRepository;
        private readonly IAppNotifier _appNotifier;

        public NotificationAppService(
            INotificationDefinitionManager notificationDefinitionManager,
            IUserNotificationManager userNotificationManager,
            INotificationSubscriptionManager notificationSubscriptionManager,
            IRepository<TenantNotificationInfo, Guid> tenantNotificationRepository,
            IRepository<UserNotificationInfo, Guid> userNotificationRepository,
            IAppNotifier appNotifier)
        {
            _notificationDefinitionManager = notificationDefinitionManager;
            _userNotificationManager = userNotificationManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _tenantNotificationRepository = tenantNotificationRepository;
            _userNotificationRepository = userNotificationRepository;
            _appNotifier = appNotifier;
        }

        [DisableAuditing]
        public async Task<GetNotificationsOutput> GetUserNotifications(GetUserNotificationsInput input)
        {
            var totalCount = await _userNotificationManager.GetUserNotificationCountAsync(
                AbpSession.ToUserIdentifier(), input.State, input.StartDate, input.EndDate
                );

            var unreadCount = await _userNotificationManager.GetUserNotificationCountAsync(
                AbpSession.ToUserIdentifier(), UserNotificationState.Unread, input.StartDate, input.EndDate
                );
            var notifications = await _userNotificationManager.GetUserNotificationsAsync(
                AbpSession.ToUserIdentifier(), input.State, input.SkipCount, input.MaxResultCount, input.StartDate, input.EndDate
                );

            return new GetNotificationsOutput(totalCount, unreadCount, notifications);
        }

        [DisableAuditing]
        public async Task<LoadResult> GetUserNotificationsDevGrid(DataSourceLoadOptions loadOptions)
        {

            var user = AbpSession.ToUserIdentifier();

            var query = from userNotificationInfo in _userNotificationRepository.GetAll()
                        join tenantNotificationInfo in _tenantNotificationRepository.GetAll() on userNotificationInfo
                            .TenantNotificationId equals tenantNotificationInfo.Id
                        where userNotificationInfo.UserId == user.UserId
                        select new
                        {
                            userNotificationInfo,
                            tenantNotificationInfo
                        };

            var resultado = await DataSourceLoader.LoadAsync(query, loadOptions);
            return resultado;
        }

        public async Task SetAllNotificationsAsRead()
        {
            await _userNotificationManager.UpdateAllUserNotificationStatesAsync(AbpSession.ToUserIdentifier(), UserNotificationState.Read);
        }

        public async Task SetNotificationAsRead(EntityDto<Guid> input)
        {
            var userNotification = await _userNotificationManager.GetUserNotificationAsync(AbpSession.TenantId, input.Id);
            if (userNotification == null)
            {
                return;
            }

            if (userNotification.UserId != AbpSession.GetUserId())
            {
                throw new Exception(string.Format("Given user notification id ({0}) is not belong to the current user ({1})", input.Id, AbpSession.GetUserId()));
            }

            await _userNotificationManager.UpdateUserNotificationStateAsync(AbpSession.TenantId, input.Id, UserNotificationState.Read);
        }

        public async Task<GetNotificationSettingsOutput> GetNotificationSettings()
        {
            var output = new GetNotificationSettingsOutput();

            output.ReceiveNotifications = await SettingManager.GetSettingValueAsync<bool>(NotificationSettingNames.ReceiveNotifications);

            //Get general notifications, not entity related notifications.
            var notificationDefinitions = (await _notificationDefinitionManager.GetAllAvailableAsync(AbpSession.ToUserIdentifier())).Where(nd => nd.EntityType == null);

            output.Notifications = ObjectMapper.Map<List<NotificationSubscriptionWithDisplayNameDto>>(notificationDefinitions);

            var subscribedNotifications = (await _notificationSubscriptionManager
                .GetSubscribedNotificationsAsync(AbpSession.ToUserIdentifier()))
                .Select(ns => ns.NotificationName)
                .ToList();

            output.Notifications.ForEach(n => n.IsSubscribed = subscribedNotifications.Contains(n.Name));

            return output;
        }

        public async Task UpdateNotificationSettings(UpdateNotificationSettingsInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), NotificationSettingNames.ReceiveNotifications, input.ReceiveNotifications.ToString());

            foreach (var notification in input.Notifications)
            {
                if (notification.IsSubscribed)
                {
                    await _notificationSubscriptionManager.SubscribeAsync(AbpSession.ToUserIdentifier(), notification.Name);
                }
                else
                {
                    await _notificationSubscriptionManager.UnsubscribeAsync(AbpSession.ToUserIdentifier(), notification.Name);
                }
            }
        }

        public async Task DeleteNotification(EntityDto<Guid> input)
        {
            var notification = await _userNotificationManager.GetUserNotificationAsync(AbpSession.TenantId, input.Id);
            if (notification == null)
            {
                return;
            }

            if (notification.UserId != AbpSession.GetUserId())
            {
                throw new UserFriendlyException(L("ThisNotificationDoesntBelongToYou"));
            }

            await _userNotificationManager.DeleteUserNotificationAsync(AbpSession.TenantId, input.Id);
        }

        public async Task DeleteAllUserNotifications(DeleteAllUserNotificationsInput input)
        {
            await _userNotificationManager.DeleteAllUserNotificationsAsync(
                AbpSession.ToUserIdentifier(),
                input.State,
                input.StartDate,
                input.EndDate);
        }

        [AbpAuthorize(PermissionNames.Pages_Notifications_EnviarNotificacao)]
        public async Task CreateNotification(CreateNotificationDto input)
        {
            if (input.EnviarTodosUsuarios)
            {
                await _appNotifier.SendMessageAllAsync(input.Notificacao, null, NotificationSeverity.Info);
            } else
            {
                if (!input.UsuarioId.HasValue)
                {
                    throw new UserFriendlyException("Ops!", "Favor selecione um usuário!");
                }
                await _appNotifier.SendMessageAsync(new UserIdentifier(1, (long)input.UsuarioId), input.Notificacao, null, NotificationSeverity.Info);
            }
            
        }

    }
}