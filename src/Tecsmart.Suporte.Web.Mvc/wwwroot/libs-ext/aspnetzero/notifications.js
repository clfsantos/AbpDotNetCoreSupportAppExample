﻿(function ($) {
    $(function () {

        // Notifications
        var _appUserNotificationHelper = new app.UserNotificationHelper();
        var _notificationService = abp.services.app.notification;

        function bindNotificationEvents() {
            $('#setAllNotificationsAsReadLink').click(function (e) {
                e.preventDefault();
                e.stopPropagation();

                _appUserNotificationHelper.setAllAsRead(function () {
                    loadNotifications();
                });
            });

            $('.set-notification-as-read').click(function (e) {
                e.preventDefault();
                e.stopPropagation();

                var notificationId = $(this).attr("data-notification-id");
                if (notificationId) {
                    _appUserNotificationHelper.setAsRead(notificationId, function () {
                        loadNotifications();
                    });
                }
            });

            $('#openNotificationSettingsModalLink').click(function (e) {
                e.preventDefault();
                e.stopPropagation();

                _appUserNotificationHelper.openSettingsModal();
            });

            $('a.user-notification-item-clickable').click(function () {
                var url = $(this).attr('data-url');
                document.location.href = url;
            });
        }

        function loadNotifications() {
            _notificationService.getUserNotifications({
                maxResultCount: 5
            }).done(function (result) {
                result.notifications = [];
                result.unreadMessageExists = result.unreadCount > 0;
                $.each(result.items, function (index, item) {
                    var formattedItem = _appUserNotificationHelper.format(item);
                    result.notifications.push(formattedItem);
                });

                var $li = $('#header_notification_bar');

                var template = $('#headerNotificationBarTemplate').html();
                Mustache.parse(template);
                var rendered = Mustache.render(template, result);

                $li.html(rendered);

                bindNotificationEvents();
            });
        }

        abp.event.on('abp.notifications.received', function (userNotification) {
            _appUserNotificationHelper.show(userNotification);
            loadNotifications();
        });

        abp.event.on('app.notifications.refresh', function () {
            loadNotifications();
        });

        abp.event.on('app.notifications.read', function (userNotificationId) {
            loadNotifications();
        });

        abp.event.on('app.notifications.readgrid', function (userNotificationId) {
            if (userNotificationId) {
                _appUserNotificationHelper.setAsRead(userNotificationId, function () {
                    loadNotifications();
                });
            }
        });
        

        // Init

        function init() {
            loadNotifications();
        }

        init();
    });
})(jQuery);
