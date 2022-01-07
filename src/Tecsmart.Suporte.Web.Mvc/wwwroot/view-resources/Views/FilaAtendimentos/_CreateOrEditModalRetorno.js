(function ($) {
    app.modals.CreateOrEditModalRetorno = function () {

        var _filaRetorno = abp.services.app.filaRetorno;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$filaRetornoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$filaRetornoInformationsForm = _modalManager.getModal().find('form[name=FilaRetornoInformationsForm]');

            $('#formFilaRetorno').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formFilaRetorno').dxForm('instance').validate().isValid) {
                return;
            }

            var filaRetorno = _$filaRetornoInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _filaRetorno.createOrEdit(
                filaRetorno
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('filaRetorno.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);