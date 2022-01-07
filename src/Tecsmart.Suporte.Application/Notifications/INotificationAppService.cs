using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Tecsmart.Suporte.Notifications.Dto;

namespace Tecsmart.Suporte.Notifications
{
    public interface INotificationAppService : IApplicationService
    {
        Task<GetNotificationsOutput> GetUserNotifications(GetUserNotificationsInput input);
        Task<LoadResult> GetUserNotificationsDevGrid(DataSourceLoadOptions loadOptions);


        Task SetAllNotificationsAsRead();

        Task SetNotificationAsRead(EntityDto<Guid> input);

        Task<GetNotificationSettingsOutput> GetNotificationSettings();

        Task UpdateNotificationSettings(UpdateNotificationSettingsInput input);

        Task DeleteNotification(EntityDto<Guid> input);

        Task DeleteAllUserNotifications(DeleteAllUserNotificationsInput input);

        Task CreateNotification(CreateNotificationDto input);
    }
}