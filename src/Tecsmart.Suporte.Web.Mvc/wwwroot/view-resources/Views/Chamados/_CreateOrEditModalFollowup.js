(function ($) {
    app.modals.CreateOrEditModalFollowup = function () {

        var _followupService = abp.services.app.followup;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$followupInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$followupInformationsForm = _modalManager.getModal().find('form[name=FollowupInformationsForm]');
            _$followupInformationsForm.validate();

            $('#formFollowup').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formFollowup').dxForm('instance').validate().isValid) {
                return;
            }

            var followup = _$followupInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _followupService.createOrEdit(
                followup
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('followup.createoredit', followup);
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);