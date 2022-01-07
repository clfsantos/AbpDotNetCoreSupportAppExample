(function ($) {
    abp.event.on('filtrar.state', function (item) {
        gridAssistenciasRelatorioInstance().state(JSON.parse(item));
    });
})(jQuery);

function viewFilterAssistenciasRelatorio(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'GridStates/ViewGridStatesFiltersModal',
        scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_GridStatesFiltersView.js',
        modalClass: 'GridStatesFiltersView'
    });
    _createOrEditModal.open({ tela: 'AssistenciasRelatorio', state: JSON.stringify(gridAssistenciasRelatorioInstance().state()) });
}

function gridAssistenciasToolbar(e) {
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
    },
    {
        location: "after",
        widget: "dxButton",
        options: {
            text: "",
            icon: "far fa-file-pdf",
            hint: "Exportar para PDF",
            onClick: function (e) {
                var doc = new jsPDF();
                DevExpress.pdfExporter.exportDataGrid({
                    jsPDFDocument: doc,
                    component: dataGrid
                }).then(function () {
                    doc.save("Assistencias.pdf");
                });
            }
        }
    });
}

function gridAssistenciasRelatorioInstance() {
    return $("#gridAssistenciasRelatorio").dxDataGrid("instance");
}

function editChamadoExterno(e) {
    window.open(
        '/Chamados/Editar/' + e.row.data.chamadoId,
        '_blank'
    );
}
