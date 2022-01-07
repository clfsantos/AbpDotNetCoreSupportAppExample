(function ($) {
    app.modals.CreateOrEditModalCliente = function () {

        var _clienteService = abp.services.app.cliente;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$clientesInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$clientesInformationsForm = _modalManager.getModal().find('form[name=ClientesInformationsForm]');
            _$clientesInformationsForm.validate();

            $('#formClientes').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formClientes').dxForm('instance').validate().isValid) {
                return;
            }

            var cliente = _$clientesInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _clienteService.createOrEdit(
                cliente
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('cliente.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);