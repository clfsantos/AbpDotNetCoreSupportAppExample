(function ($) {
    app.modals.CreateOrEditModalAssistencia = function () {

        var _assistenciaService = abp.services.app.assistencia;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$assistenciaInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$assistenciaInformationsForm = _modalManager.getModal().find('form[name=AssistenciaInformationsForm]');

            $('#formAssistencia').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formAssistencia').dxForm('instance').validate().isValid) {
                return;
            }

            var assistencia = _$assistenciaInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _assistenciaService.createOrEdit(
                assistencia
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('assistencia.createoredit', assistencia);
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);