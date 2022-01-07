(function ($) {
    abp.event.on('fluxo.createoredit', function () {
        gridFluxoGetInstance().refresh();
    });
})(jQuery);

function gridFluxoGetInstance() {
    return $('#gridFluxo').dxDataGrid('instance');
}

function onToolbarFluxoPreparing(e) {
    e.toolbarOptions.items.unshift({
        location: "before",
        widget: "dxButton",
        options: {
            icon: "add",
            text: "",
            type: "default",
            onClick: function () {
                novoFluxo();
            }
        }
    });
}

function novoFluxo() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'FluxoAtendimentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/FluxoAtendimentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalFluxo'
    });
    _createOrEditModal.open();
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
