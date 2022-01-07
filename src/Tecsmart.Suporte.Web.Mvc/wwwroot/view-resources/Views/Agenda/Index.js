(function ($) {
    abp.event.on('tarefa.createoredit', function (item) {
        var schedulerInstance = $("#dxAgenda").dxScheduler("instance");
        schedulerInstance.getDataSource().reload(); 
    });
})(jQuery);

function onAppointmentClick(e) {
    e.cancel = true;
    var _createOrEditModalTarefa = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalTarefa',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalTarefa.js',
        modalClass: 'CreateOrEditModalTarefa'
    });
    _createOrEditModalTarefa.open({ id: e.appointmentData.id, chamadoId: e.appointmentData.chamadoId });
}
