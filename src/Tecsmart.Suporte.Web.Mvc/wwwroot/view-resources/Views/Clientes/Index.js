(function ($) {
    abp.event.on('cliente.createoredit', function () {
        gridGetInstance().refresh();
    });
})(jQuery);

function gridGetInstance() {
    return $('#gridClientes').dxDataGrid('instance');
}

function editarCliente(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Clientes/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Clientes/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalCliente',
        modalSize: 'modal-lg modal-fluid modal-full-height modal-dialog-scrollable'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function integracaoOmieCompleta(e) {
    integracaoOmie(true);
}

function integracaoOmieRapida(e) {
    integracaoOmie(false);
}

function integracaoOmie(completa) {
    $('#loadIndicatorContainer').dxLoadIndicator('instance').option("visible", true);
    $('#btIntegracaoOmieCompleta').dxButton('instance').option("visible", false);
    $('#btIntegracaoOmieRapida').dxButton('instance').option("visible", false);
    var _clienteService = abp.services.app.cliente;
    _clienteService.integracaoOmie({
        id: completa
    }).done(function () {
        $('#loadIndicatorContainer').dxLoadIndicator('instance').option("visible", false);
        $('#btIntegracaoOmieCompleta').dxButton('instance').option("visible", true);
        $('#btIntegracaoOmieRapida').dxButton('instance').option("visible", true);
        gridGetInstance().refresh();
    });
}

function onToolbarPreparingClientes(e) {
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

function formataRowsClientes(e) {
    if (e.rowType == 'data') {
        if (e.data.isClienteMensalista) {
            e.rowElement.css('backgroundColor', '#66BB6A');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
        }
        if (e.data.isClienteBloqueado) {
            e.rowElement.css('backgroundColor', '#f44336');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
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
