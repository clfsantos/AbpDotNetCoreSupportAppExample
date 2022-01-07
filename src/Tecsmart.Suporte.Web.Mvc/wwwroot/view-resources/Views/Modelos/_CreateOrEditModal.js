(function ($) {
    app.modals.CreateOrEditModalModelo = function () {

        var _modeloService = abp.services.app.modelo;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$modeloInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$modeloInformationsForm = _modalManager.getModal().find('form[name=ModeloInformationsForm]');

            $('#formModelo').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formModelo').dxForm('instance').validate().isValid) {
                return;
            }

            var modelo = _$modeloInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _modeloService.createOrEdit(
                modelo
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('modelo.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);