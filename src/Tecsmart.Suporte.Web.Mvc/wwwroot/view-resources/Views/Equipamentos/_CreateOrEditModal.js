(function ($) {
    app.modals.CreateOrEditModalEquipamento = function () {

        var _equipamentoService = abp.services.app.equipamento;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$equipamentoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$equipamentoInformationsForm = _modalManager.getModal().find('form[name=EquipamentosInformationsForm]');

            $('#formEquipamentos').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formEquipamentos').dxForm('instance').validate().isValid) {
                return;
            }

            var equipamento = _$equipamentoInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _equipamentoService.createOrEdit(
                equipamento
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('equipamento.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);