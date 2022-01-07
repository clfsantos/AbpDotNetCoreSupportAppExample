(function ($) {
    abp.event.on('modelo.createoredit', function () {
        gridModelosGetInstance().refresh();
    });
    abp.event.on('fabricante.createoredit', function (item) {
        var selectBoxDataSource = $('#modeloFabricanteId').dxSelectBox("getDataSource");
        selectBoxDataSource.reload();
        $('#modeloFabricanteId').dxSelectBox("instance").option("value", item.id);
    });
    abp.event.on('categoria.createoredit', function (item) {
        var selectBoxDataSource = $('#modeloCategoriaId').dxSelectBox("getDataSource");
        selectBoxDataSource.reload();
        $('#modeloCategoriaId').dxSelectBox("instance").option("value", item.id);
    });
})(jQuery);

function gridModelosGetInstance() {
    return $('#gridModelos').dxDataGrid('instance');
}

function addModelo() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Modelos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Modelos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalModelo'
    });
    _createOrEditModal.open();
}

function editModelo(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Modelos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Modelos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalModelo'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteModelo(e) {
    var _modeloService = abp.services.app.modelo;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _modeloService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridModelosGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}

function cadastrarFabricanteExterno() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Fabricantes/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Fabricantes/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalFabricante'
    });
    _createOrEditModal.open();
}

function cadastrarCategoriaExterno() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Categorias/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Categorias/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalCategoria'
    });
    _createOrEditModal.open();
}
