(function ($) {
    app.modals.CreateOrEditModalFluxo = function () {

        var _fluxoService = abp.services.app.fluxo;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$fluxoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$fluxoInformationsForm = _modalManager.getModal().find('form[name=FluxoInformationsForm]');

            $('#formFluxo').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formFluxo').dxForm('instance').validate().isValid) {
                return;
            }

            var fluxo = _$fluxoInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _fluxoService.createOrEdit(
                fluxo
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('fluxo.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);