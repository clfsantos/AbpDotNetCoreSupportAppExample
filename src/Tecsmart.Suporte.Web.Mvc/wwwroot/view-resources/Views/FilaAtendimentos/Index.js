(function ($) {
    abp.event.on('fila.createoredit', function () {
        gridFilaGetInstance().refresh();
    });
    abp.event.on('filaRetorno.createoredit', function () {
        gridFilaGetInstance().refresh();
    });
})(jQuery);

function gridFilaGetInstance() {
    return $('#gridFila').dxDataGrid('instance');
}

function onToolbarFluxoPreparing(e) {
    e.toolbarOptions.items.unshift({
        location: "after",
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

function novaFila() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'FilaAtendimentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/FilaAtendimentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalFila'
    });
    _createOrEditModal.open();
}

function editarFila(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'FilaAtendimentos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/FilaAtendimentos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalFila'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function atenderFila(e) {
    if (e.row.data.atendido) {
        abp.message.warn('Já foi atendido.', 'Ops!');
        return;
    }
    var _filaService = abp.services.app.filaAtendimento;
    abp.message.confirm(
        '',
        'Atender?',
        function (isConfirmed) {
            if (isConfirmed) {
                _filaService.atender({
                    id: e.row.data.id
                }).done(function () {
                    gridFilaGetInstance().refresh();
                    abp.notify.info('Atendido!');
                });
            }
        }
    );
}

function cancelarFila(e) {
    if (e.row.data.atendido) {
        abp.message.warn('Já foi atendido.', 'Ops!');
        return;
    }
    var _filaService = abp.services.app.filaAtendimento;
    abp.message.confirm(
        '',
        'Cancelar Atendimento?',
        function (isConfirmed) {
            if (isConfirmed) {
                _filaService.cancelar({
                    id: e.row.data.id
                }).done(function () {
                    gridFilaGetInstance().refresh();
                    abp.notify.info('Cancelado com Sucesso!');
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

function cadastrarFilaRetornoModal(e) {
    if (e.row.data.atendido) {
        abp.message.warn('', 'Não é possível cadastrar retornos para atendimentos que já foram atendidos!');
        return;
    }
    var _createOrEditModalFilaRetorno = new app.ModalManager({
        viewUrl: abp.appPath + 'FilaAtendimentos/CreateOrEditModalRetorno',
        scriptUrl: abp.appPath + 'view-resources/Views/FilaAtendimentos/_CreateOrEditModalRetorno.js',
        modalClass: 'CreateOrEditModalRetorno'
    });
    _createOrEditModalFilaRetorno.open({ filaAtendimentoId: e.row.data.id });
}

function editarFilaRetornoModal(e) {
    if (abp.session.userId != e.row.data.usuarioId) {
        abp.message.warn('', 'Somente o usuário que cadastrou o retorno pode editar!');
        return;
    }
    var _createOrEditModalFilaRetorno = new app.ModalManager({
        viewUrl: abp.appPath + 'FilaAtendimentos/CreateOrEditModalRetorno',
        scriptUrl: abp.appPath + 'view-resources/Views/FilaAtendimentos/_CreateOrEditModalRetorno.js',
        modalClass: 'CreateOrEditModalRetorno'
    });
    _createOrEditModalFilaRetorno.open({ id: e.row.data.id, filaAtendimentoId: e.row.data.filaAtendimentoId });
}