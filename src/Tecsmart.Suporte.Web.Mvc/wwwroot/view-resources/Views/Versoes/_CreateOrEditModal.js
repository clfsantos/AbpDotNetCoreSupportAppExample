(function ($) {
    app.modals.CreateOrEditModalRelease = function () {

        var _releaseService = abp.services.app.release;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$releasesInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$releasesInformationsForm = _modalManager.getModal().find('form[name=ReleasesInformationsForm]');

            $('#formReleases').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formReleases').dxForm('instance').validate().isValid) {
                return;
            }

            var release = _$releasesInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _releaseService.createOrEdit(
                release
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('release.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);