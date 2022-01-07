using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Web.Models;
using DevExtreme.AspNet.Data.ResponseModel;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Tecsmart.Suporte.Controllers;
using Tecsmart.Suporte.Notifications;
using Tecsmart.Suporte.Notifications.Dto;
using Tecsmart.Suporte.Web.Models.Notifications;

namespace Tecsmart.Suporte.Web.Controllers
{
    [AbpMvcAuthorize]
    public class NotificationsController : SuporteControllerBase
    {
        private readonly INotificationAppService _notificationApp;

        public NotificationsController(INotificationAppService notificationApp)
        {
            _notificationApp = notificationApp;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [DontWrapResult]
        public async Task<LoadResult> GetAllNotifications(DataSourceLoadOptions loadOptions)
        {
            return await _notificationApp.GetUserNotificationsDevGrid(loadOptions);
        }

        public PartialViewResult CreateNotificationModal()
        {
            GetNotificationForEditOutput getNotificationForEditOutput;

            getNotificationForEditOutput = new GetNotificationForEditOutput
            {
                Notification = new CreateNotificationDto()
            };
            
            var viewModel = new CreateNotificationViewModel()
            {
                Notification = getNotificationForEditOutput.Notification
            };

            return PartialView("_CreateModal", viewModel);
        }

    }
}