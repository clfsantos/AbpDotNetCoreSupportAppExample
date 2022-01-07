(function ($) {
    app.modals.CreateOrEditModalProduto = function () {

        var _produtoService = abp.services.app.produto;
        var l = abp.localization.getSource('Suporte');
        var _modalManager;
        var _$produtoInformationsForm = null;

        this.init = function (modalManager) {
            _modalManager = modalManager;

            _$produtoInformationsForm = _modalManager.getModal().find('form[name=ProdutosInformationsForm]');

            $('#formProdutos').dxForm('instance').validate();
        };

        this.save = function () {
            if (!$('#formProdutos').dxForm('instance').validate().isValid) {
                return;
            }

            var produto = _$produtoInformationsForm.serializeFormToObject();

            _modalManager.setBusy(true);
            _produtoService.createOrEdit(
                produto
            ).done(function () {
                abp.notify.info(l('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('produto.createoredit');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };
    };
})(jQuery);