(function ($) {
    abp.event.on('categoria.createoredit', function () {
        gridCategoriasGetInstance().refresh();
    });
})(jQuery);

function gridCategoriasGetInstance() {
    return $('#gridCategorias').dxDataGrid('instance');
}

function addCategoria() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Categorias/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Categorias/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalCategoria'
    });
    _createOrEditModal.open();
}

function editCategoria(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Categorias/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Categorias/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalCategoria'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteCategoria(e) {
    var _categoriaService = abp.services.app.categoria;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _categoriaService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridCategoriasGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
