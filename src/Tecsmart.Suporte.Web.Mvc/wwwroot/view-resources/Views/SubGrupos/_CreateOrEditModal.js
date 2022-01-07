(function ($) {
    app.modals.CreateOrEditModalSubGrupo = function () {

        var _subGrupoService = abp.services.app.subGrupo;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$subGrupoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$subGrupoInformationsForm = _modalManager.getModal().find('form[name=SubGruposInformationsForm]');

            $('#formSubGrupos').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formSubGrupos').dxForm('instance').validate().isValid) {
                return;
            }

            var subGrupo = _$subGrupoInformationsForm.serializeFormToObject();
            var grupos = $('#tagBoxGrupos').dxTagBox('instance').option('value');

            _modalManager.setBusy(true);
            _subGrupoService.createOrEdit({
                subGrupo: subGrupo,
                grupos: grupos
            }).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('subGrupo.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);