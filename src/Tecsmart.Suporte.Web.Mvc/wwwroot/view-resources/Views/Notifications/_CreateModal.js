(function ($) {
    app.modals.CreateModalNotification = function () {

        var _notificationService = abp.services.app.notification;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$notificationInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$notificationInformationsForm = _modalManager.getModal().find('form[name=NotificationInformationsForm]');

            $('#formNotification').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formNotification').dxForm('instance').validate().isValid) {
                return;
            }

            var notification = _$notificationInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _notificationService.createNotification(
                notification
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('notification.create');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);