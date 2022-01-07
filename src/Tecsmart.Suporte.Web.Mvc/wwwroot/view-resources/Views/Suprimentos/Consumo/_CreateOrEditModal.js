(function ($) {
    app.modals.CreateOrEditModalSuprimentoConsumo = function () {

        var _suprimentoConsumoService = abp.services.app.suprimentoConsumo;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$suprimentosConsumoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$suprimentosConsumoInformationsForm = _modalManager.getModal().find('form[name=SuprimentosConsumoInformationsForm]');

            $('#formSuprimentosConsumo').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formSuprimentosConsumo').dxForm('instance').validate().isValid) {
                return;
            }

            var suprimentoConsumo = _$suprimentosConsumoInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _suprimentoConsumoService.createOrEdit(
                suprimentoConsumo
            ).done(function (result) {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('suprimentoConsumo.createoredit', { id: result });
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);