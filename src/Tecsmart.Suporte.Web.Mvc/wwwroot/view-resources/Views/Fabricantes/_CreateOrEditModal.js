(function ($) {
    app.modals.CreateOrEditModalFabricante = function () {

        var _fabricanteService = abp.services.app.fabricante;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$fabricanteInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$fabricanteInformationsForm = _modalManager.getModal().find('form[name=FabricantesInformationsForm]');

            $('#formFabricantes').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formFabricantes').dxForm('instance').validate().isValid) {
                return;
            }

            var fabricante = _$fabricanteInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _fabricanteService.createOrEdit(
                fabricante
            ).done(function (result) {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('fabricante.createoredit', { id: result });
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);