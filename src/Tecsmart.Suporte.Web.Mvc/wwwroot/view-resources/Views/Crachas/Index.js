(function ($) {
    carregaCrachasInfo();
    abp.event.on('cracha.createoredit', function () {
        gridCrachasGetInstance().refresh();
        carregaCrachasInfo();
    });
    abp.event.on('filtrar.state', function (item) {
        gridCrachasGetInstance().state(JSON.parse(item));
    });
})(jQuery);

function carregaCrachasInfo() {
    $.ajax({
        type: "POST",
        url: abp.appPath + 'Crachas/CarregaCrachasInfo',
        dataType: 'html',
    }).done(function (retorno) {
        $('#container-crachas-info').html(retorno);
    });
}

function gridCrachasGetInstance() {
    return $('#gridCrachas').dxDataGrid('instance');
}

function viewFilterCrachas(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'GridStates/ViewGridStatesFiltersModal',
        scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_GridStatesFiltersView.js',
        modalClass: 'GridStatesFiltersView'
    });
    _createOrEditModal.open({ tela: 'Crachas', state: JSON.stringify(gridCrachasGetInstance().state()) });
}

function onToolbarPreparingCrachas(e) {
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

function novoPedidoCracha() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Crachas/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Crachas/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalCracha'
    });
    _createOrEditModal.open();
}

function editarPedidoCracha(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Crachas/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Crachas/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalCracha'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function excluirPedidoCracha(e) {
    if (e.row.data.status != 1) {
        abp.message.warn('', 'Somente pedidos com o status "Pendente" podem ser excluídos!');
        return;
    }
    var _crachaService = abp.services.app.cracha;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _crachaService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridCrachasGetInstance().refresh();
                    carregaCrachasInfo();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}

function formatRowCrachas(e) {
    if (e.rowType == 'data') {
        if (e.data.status == 3) {
            e.rowElement.css('backgroundColor', '#E0E0E0');
        }
    }
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
