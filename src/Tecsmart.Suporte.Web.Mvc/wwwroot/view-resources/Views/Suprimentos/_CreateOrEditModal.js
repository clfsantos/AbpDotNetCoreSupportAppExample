(function ($) {
    app.modals.CreateOrEditModalSuprimento = function () {

        var _suprimentoService = abp.services.app.suprimento;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$suprimentosInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$suprimentosInformationsForm = _modalManager.getModal().find('form[name=SuprimentosInformationsForm]');

            $('#formSuprimentos').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formSuprimentos').dxForm('instance').validate().isValid) {
                return;
            }

            var suprimento = _$suprimentosInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _suprimentoService.createOrEdit(
                suprimento
            ).done(function (result) {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('suprimento.createoredit', { id: result });
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);