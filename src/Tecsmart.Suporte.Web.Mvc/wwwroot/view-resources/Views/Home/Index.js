$(function () {

});

function editChamadoExterno(e) {
    window.open(
        '/Chamados/Editar/' + e.row.data.chamadoId,
        '_blank'
    );
}

function chartChamadosDiaClick(e) {
    var sourceChamadosTecnico = $("#chartChamadosTecnico").dxPieChart("getDataSource");
    sourceChamadosTecnico.filter(["dataAbertura", ">", e.target.data.dataAbertura]);
    sourceChamadosTecnico.load();
}

function chartChamadosAnoClick(e) {
    var source = $("#chartChamadosMes").dxChart("getDataSource");
    source.filter(["ano", ">", e.target.data.ano]);
    source.load();
}

function onChangeChamadosDia(e) {
    console.log(e);
    var d = new Date();
    d.setDate(d.getDate() - e.value);
    console.log(d);
    var source = $("#chartChamadosDia").dxChart("getDataSource");
    source.filter(["dataAbertura", ">", d]);
    source.load();

    var sourceChamadosTecnico = $("#chartChamadosTecnico").dxPieChart("getDataSource");
    sourceChamadosTecnico.filter(["dataAbertura", ">", d]);
    sourceChamadosTecnico.load();
}