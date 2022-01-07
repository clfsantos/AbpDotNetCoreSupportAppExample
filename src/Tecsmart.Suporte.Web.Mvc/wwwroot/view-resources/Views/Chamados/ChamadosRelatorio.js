(function ($) {
    abp.event.on('filtrar.state', function (item) {
        gridChamadosRelatorioInstance().state(JSON.parse(item));
    });
})(jQuery);

function viewFilterChamadosRelatorio(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'GridStates/ViewGridStatesFiltersModal',
        scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_GridStatesFiltersView.js',
        modalClass: 'GridStatesFiltersView'
    });
    _createOrEditModal.open({ tela: 'ChamadosRelatorio', state: JSON.stringify(gridChamadosRelatorioInstance().state()) });
}

function gridChamadosToolbar(e) {
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
                    doc.save("Chamados.pdf");
                });
            }
        }
    });
}

function gridChamadosRelatorioInstance() {
    return $("#gridChamadosRelatorio").dxDataGrid("instance");
}

function formatRow(e) {
    if (e.rowType == 'data') {
        if (e.data.status == 3) {
            e.rowElement.css('backgroundColor', '#ef5350');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
        }
    }
}

function editChamadoExterno(e) {
    window.open(
        '/Chamados/Editar/' + e.row.data.id,
        '_blank'
    );
}
