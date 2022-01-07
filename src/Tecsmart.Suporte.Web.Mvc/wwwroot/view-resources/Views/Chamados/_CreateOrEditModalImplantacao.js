(function ($) {
    app.modals.CreateOrEditModalImplantacao = function () {

        var _implantacaoService = abp.services.app.implantacao;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$implantacaoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$implantacaoInformationsForm = _modalManager.getModal().find('form[name=ImplantacaoInformationsForm]');
            _$implantacaoInformationsForm.validate();

            $('#formImplantacao').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formImplantacao').dxForm('instance').validate().isValid) {
                return;
            }

            var implantacao = _$implantacaoInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _implantacaoService.createOrEdit(
                implantacao
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('implantacao.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);