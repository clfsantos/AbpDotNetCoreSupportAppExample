(function ($) {
    abp.event.on('suprimento.createoredit', function () {
        gridSuprimentosGetInstance().refresh();
    });
    abp.event.on('suprimentoConsumo.createoredit', function () {
        gridSuprimentosConsumoGetInstance().refresh();
    });
})(jQuery);

function gridSuprimentosGetInstance() {
    return $('#gridSuprimentos').dxDataGrid('instance');
}

function gridSuprimentosConsumoGetInstance() {
    return $('#gridSuprimentosConsumo').dxDataGrid('instance');
}

function addSuprimento() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Suprimentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Suprimentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalSuprimento'
    });
    _createOrEditModal.open();
}

function addSuprimentoConsumo() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Suprimentos/CreateOrEditModalConsumo',
        scriptUrl: abp.appPath + 'view-resources/Views/Suprimentos/Consumo/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalSuprimentoConsumo'
    });
    _createOrEditModal.open();
}

function editSuprimento(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Suprimentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Suprimentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalSuprimento'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function editSuprimentoConsumo(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Suprimentos/CreateOrEditModalConsumo',
        scriptUrl: abp.appPath + 'view-resources/Views/Suprimentos/Consumo/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalSuprimentoConsumo'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteSuprimento(e) {
    var _suprimentoService = abp.services.app.suprimento;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _suprimentoService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridSuprimentosGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}

function deleteSuprimentoConsumo(e) {
    var _suprimentoConsumoService = abp.services.app.suprimentoConsumo;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _suprimentoConsumoService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridSuprimentosConsumoGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
