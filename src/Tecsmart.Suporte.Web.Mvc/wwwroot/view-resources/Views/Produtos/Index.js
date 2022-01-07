(function ($) {
    abp.event.on('produto.createoredit', function () {
        gridProdutosGetInstance().refresh();
    });
})(jQuery);

function gridProdutosGetInstance() {
    return $('#gridProdutos').dxDataGrid('instance');
}

function addProduto() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Produtos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Produtos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalProduto'
    });
    _createOrEditModal.open();
}

function editProduto(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Produtos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Produtos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalProduto'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteProduto(e) {
    var _produtoService = abp.services.app.produto;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _produtoService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridProdutosGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
