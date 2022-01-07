(function ($) {
    app.modals.CreateOrEditModalGridState = function () {

        var _gridStateService = abp.services.app.gridState;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$gridStateInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$gridStateInformationsForm = _modalManager.getModal().find('form[name=GridStateInformationsForm]');

            $('#formGridState').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formGridState').dxForm('instance').validate().isValid) {
                return;
            }

            var state = _$gridStateInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _gridStateService.createOrEdit(
                state
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('state.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);