(function ($) {
    app.modals.CreateOrEditModalCracha = function () {

        var _crachaService = abp.services.app.cracha;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$crachaInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$crachaInformationsForm = _modalManager.getModal().find('form[name=CrachaInformationsForm]');

            $('#formCracha').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formCracha').dxForm('instance').validate().isValid) {
                return;
            }

            var cracha = _$crachaInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _crachaService.createOrEdit(
                cracha
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('cracha.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);