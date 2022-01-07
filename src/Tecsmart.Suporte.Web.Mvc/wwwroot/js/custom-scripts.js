(function ($) {
    DevExpress.localization.locale("pt");

    DevExpress.ui.dxDataGrid.defaultOptions({
        options: {
            hoverStateEnabled: true,
            focusedRowEnabled: true,
            showBorders: false,
            showRowLines: true,
            allowColumnReordering: true,
            allowColumnResizing: true,
            remoteOperations: true,
            scrolling: {
                mode: "virtual",
                rowRenderingMode: "virtual"
            },
            paging: {
                pageSize: 15
            },
            height: "auto",
            elementAttr: {
                style: "max-height:600px",
            },
            filterRow: {
                visible: true
            },
            headerFilter: {
                visible: true,
                allowSearch: true
            },
            groupPanel: {
                visible: true,
                emptyPanelText: "Arraste a coluna aqui para agrupar por ela"
            },
            columnChooser: {
                enabled: true,
                allowSearch: true,
                mode: "dragAndDrop"
            },
            columnAutoWidth: true,
            columnFixing: {
                enabled: true
            }
        }
    });

    DevExpress.ui.dxSelectBox.defaultOptions({
        options: {

        }
    });

    qtdFilaAtendimento();
    setInterval(qtdFilaAtendimento, 5000);

    abp.event.on('state.createoredit', function () {
        gridStatesGetInstance().refresh();
    });

})(jQuery);

function qtdFilaAtendimento() {
    var _filaService = abp.services.app.filaAtendimento;
    _filaService.qtdFilaAtendimento(

    ).done(function (result) {
        if (result > 3) {
            $(".custom-badge").addClass("badge-danger");
            $(".custom-badge").removeClass("badge-info");
            $(".custom-badge").removeClass("badge-warning");
        } else if (result > 2) {
            $(".custom-badge").addClass("badge-warning");
            $(".custom-badge").removeClass("badge-info");
            $(".custom-badge").removeClass("badge-danger");
        } else if (result <= 2) {
            $(".custom-badge").addClass("badge-info");
            $(".custom-badge").removeClass("badge-warning");
            $(".custom-badge").removeClass("badge-danger");
        }
        
        $(".custom-badge").html(result);
    });
}

function gridStatesGetInstance() {
    return $('#gridStates').dxDataGrid('instance');
}

function onToolbarPreparingGridStates(e) {
    e.toolbarOptions.items.unshift({
        location: "before",
        widget: "dxButton",
        options: {
            text: "",
            icon: "add",
            hint: "Novo Filtro",
            type: "default",
            onClick: function (e) {
                var tela = $('[name=tela]').val();
                var state = $('[name=state]').val();
                var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'GridStates/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditModalGridState'
                });
                _createOrEditModal.open({ tela: tela, state: state });
            }
        }
    });
}

function gridStatesDblClick(e) {
    abp.event.trigger('filtrar.state', e.row.data.state);
    $('.modal').modal('hide');
}

function editFiltroState(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'GridStates/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalGridState'
    });
    _createOrEditModal.open({ id: e.row.data.id, tela: e.row.data.tela, state: e.row.data.state });
}

function delFiltroState(e) {
    var _gridStateService = abp.services.app.gridState;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _gridStateService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridStatesGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}