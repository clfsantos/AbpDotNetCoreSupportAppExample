(function ($) {
    app.modals.CreateOrEditModalTarefa = function () {

        var _tarefaService = abp.services.app.tarefa;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$tarefaInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$tarefaInformationsForm = _modalManager.getModal().find('form[name=TarefaInformationsForm]');
            _$tarefaInformationsForm.validate();

            $('#formTarefa').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formTarefa').dxForm('instance').validate().isValid) {
                return;
            }

            var tarefa = _$tarefaInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _tarefaService.createOrEdit(
                tarefa
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('tarefa.createoredit', tarefa);
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);