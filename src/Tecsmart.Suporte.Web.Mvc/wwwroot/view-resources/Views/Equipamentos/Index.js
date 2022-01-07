(function ($) {
    abp.event.on('equipamento.createoredit', function () {
        gridEquipamentosGetInstance().refresh();
    });
    abp.event.on('filtrar.state', function (item) {
        gridEquipamentosGetInstance().state(JSON.parse(item));
    });
})(jQuery);

function gridEquipamentosGetInstance() {
    return $('#gridEquipamentos').dxDataGrid('instance');
}

function gridEquipamentosToolbar(e) {
    var dataGrid = e.component;
    e.toolbarOptions.items.unshift({
        location: "after",
        widget: "dxButton",
        options: {
            text: "",
            icon: "fas fa-sync",
            hint: "Limpar filtros e voltar ao estado inicial",
            onClick: function (e) {
                dataGrid.state('{}');
            }
        }
    });
}

function viewFilterEquipamentos(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'GridStates/ViewGridStatesFiltersModal',
        scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_GridStatesFiltersView.js',
        modalClass: 'GridStatesFiltersView'
    });
    _createOrEditModal.open({ tela: 'Equipamentos', state: JSON.stringify(gridEquipamentosGetInstance().state()) });
}

function addEquipamento() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Equipamentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Equipamentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalEquipamento'
    });
    _createOrEditModal.open();
}

function editEquipamento(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Equipamentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Equipamentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalEquipamento'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteEquipamento(e) {
    var _equipamentoService = abp.services.app.equipamento;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _equipamentoService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridEquipamentosGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}

function formataComboClientes(e) {
    if (e.rowType == 'data') {
        if (e.data.isClienteMensalista) {
            e.rowElement.css('backgroundColor', '#66BB6A');
        }
        if (e.data.isClienteBloqueado) {
            e.rowElement.css('backgroundColor', '#f44336');
        }
    }
}

function formatCNPJ(e) {
    var cpfcnpj = e;
    if (cpfcnpj.length > 11) {
        cpfcnpj = Inputmask.format(e, { alias: "99.999.999/9999-99" });
    } else {
        cpfcnpj = Inputmask.format(e, { alias: "999.999.999-99" });
    }
    return cpfcnpj;
}
