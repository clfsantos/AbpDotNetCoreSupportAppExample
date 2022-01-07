(function ($) {
    abp.event.on('notification.create', function () {
        $('#gridNotifications').dxDataGrid('instance').refresh();
    });
})(jQuery);

function dataMessageTxt(e) {
    var obj = JSON.parse(e.value);
    return obj.Message;
}

function checkRead(e) {
    if (e.row.data.userNotificationInfo.state == 1) {
        return false;
    }
    else {
        return true;
    }
}

function formatRows(e) {
    if (e.rowType == 'data') {
        if (e.data.userNotificationInfo.state != 1) {
            e.rowElement.css('font-weight', 'bold');
        }
    }
}

function marcarComoLida(e) {
    var notificationId = e.row.data.userNotificationInfo.id;
    abp.event.trigger('app.notifications.readgrid', notificationId);
    $('#gridNotifications').dxDataGrid('instance').refresh();
}

function addNotification() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Notifications/CreateNotificationModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Notifications/_CreateModal.js',
        modalClass: 'CreateModalNotification'
    });
    _createOrEditModal.open();
}