(function ($) {
    abp.event.on('fabricante.createoredit', function () {
        gridFabricantesGetInstance().refresh();
    });
})(jQuery);

function gridFabricantesGetInstance() {
    return $('#gridFabricantes').dxDataGrid('instance');
}

function addFabricante() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Fabricantes/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Fabricantes/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalFabricante'
    });
    _createOrEditModal.open();
}

function editFabricante(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Fabricantes/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Fabricantes/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalFabricante'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteFabricante(e) {
    var _fabricanteService = abp.services.app.fabricante;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _fabricanteService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridFabricantesGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
