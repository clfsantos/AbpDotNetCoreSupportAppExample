(function ($) {
    app.modals.CreateOrEditModalCategoria = function () {

        var _categoriaService = abp.services.app.categoria;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$categoriaInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$categoriaInformationsForm = _modalManager.getModal().find('form[name=CategoriasInformationsForm]');

            $('#formCategorias').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formCategorias').dxForm('instance').validate().isValid) {
                return;
            }

            var categoria = _$categoriaInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _categoriaService.createOrEdit(
                categoria
            ).done(function (result) {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('categoria.createoredit', { id: result });
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);