(function ($) {
    app.modals.CreateOrEditModalGrupo = function () {

        var _grupoService = abp.services.app.grupo;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$grupoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$grupoInformationsForm = _modalManager.getModal().find('form[name=GruposInformationsForm]');

            $('#formGrupos').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formGrupos').dxForm('instance').validate().isValid) {
                return;
            }

            var grupo = _$grupoInformationsForm.serializeFormToObject();
            var produtos = $('#tagBoxProdutos').dxTagBox('instance').option('value');

            _modalManager.setBusy(true);
            _grupoService.createOrEdit({
                grupo: grupo,
                produtos: produtos
            }).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('grupo.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);