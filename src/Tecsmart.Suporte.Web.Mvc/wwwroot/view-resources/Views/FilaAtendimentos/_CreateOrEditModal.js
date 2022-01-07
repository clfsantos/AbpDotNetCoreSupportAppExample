(function ($) {
    app.modals.CreateOrEditModalFila = function () {

        var _filaService = abp.services.app.filaAtendimento;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$filaInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$filaInformationsForm = _modalManager.getModal().find('form[name=FilaInformationsForm]');

            $('#formFila').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formFila').dxForm('instance').validate().isValid) {
                return;
            }

            var fila = _$filaInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _filaService.createOrEdit(
                fila
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('fila.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);