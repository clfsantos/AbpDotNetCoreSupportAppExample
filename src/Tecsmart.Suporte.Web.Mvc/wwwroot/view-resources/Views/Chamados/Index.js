var currentTab;
var composeCount = 0;
var clienteFocus = -1;

(function ($) {
    $("#myTab").on("click", "a", function (e) {
        e.preventDefault();

        $(this).tab('show');
        $currentTab = $(this);
    });

    registerCloseEvent();

    abp.event.on('tarefa.createoredit', function (item) {
        dxGridTarefasGetInstance().refresh();
        if (item.transferirChamado == "true") {
            var hash = $currentTab[0].hash;
            craeteNewTabAndLoadUrl("", "/Chamados/CreateOrEditModal/" + item.chamadoId, hash);
            gridChamadosInstance().refresh();
        }
    });
    abp.event.on('followup.createoredit', function (item) {
        dxGridFollowupGetInstance().refresh();
        if (item.tipo == 2 || item.transferirChamado == "true") {
            var hash = $currentTab[0].hash;
            craeteNewTabAndLoadUrl("", "/Chamados/CreateOrEditModal/" + item.chamadoId, hash);
            gridChamadosInstance().refresh();
        }
    });
    abp.event.on('implantacao.createoredit', function () {
        dxGridImplantacaoGetInstance().refresh();
    });
    abp.event.on('assistencia.createoredit', function (item) {
        $.ajax({
            type: 'GET',
            url: '/Chamados/AssistenciaPartial/?id=' + item.chamadoId,
            dataType: 'html',
            cache: false,
            async: true,
            success: function (data) {
                getElement('.assistenciaPartial').html(data);
            }
        });
    });
    abp.event.on('cliente.createoredit', function () {
        var selectBoxDataSource = getElement('.dropDownBoxClientes').dxDropDownBox("getDataSource");
        selectBoxDataSource.reload();
    });
    abp.event.on('filtrar.state', function (item) {
        gridChamadosInstance().state(JSON.parse(item));
    });
})(jQuery);

function registerCloseEvent() {

    $(".closeTab").click(function () {

        //there are multiple elements which has .closeTab icon so close the tab whose close icon is clicked
        var tabContentId = $(this).parent().attr("href");

        $(this).parent().parent().remove(); //remove li of tab

        $('#myTab a:last').tab('show'); // Select first tab

        $(tabContentId).remove(); //remove respective tab content
        $currentTab = $('#myTab a:last');

    });
}

//shows the tab with passed content div id..paramter tabid indicates the div where the content resides
function showTab(tabId) {
    $('#myTab a[href="#' + tabId + '"]').tab('show');
    $currentTab = $('#myTab a[href="#' + tabId + '"]'); //implemento
}

//return current active tab
function getCurrentTab() {
    return currentTab;
}

//This function will create a new tab here and it will load the url content in tab content div.
function craeteNewTabAndLoadUrl(parms, url, loadDivSelector) {
    //$(".loader").addClass("loading");
    abp.ui.setBusy();
    $("" + loadDivSelector).load(url, function (response, status, xhr) {
        //$(".loader").removeClass("loading");
        abp.ui.clearBusy();
        if (status == "error") {
            var msg = "Sorry but there was an error getting details ! ";
            $("" + loadDivSelector).html(msg + xhr.status + " " + xhr.statusText);
            //$("" + loadDivSelector).html("Load Ajax Content Here...");
        }
    });

}

//this will return element from current tab
//example : if there are two tabs having  textarea with same id or same class name then when $("#someId") whill return both the text area from both tabs
//to take care this situation we need get the element from current tab.
function getElement(selector) {
    var tabContentId = $currentTab.attr("href");
    return $("" + tabContentId).find("" + selector);
}

function removeCurrentTab() {
    var tabContentId = $currentTab.attr("href");
    $currentTab.parent().remove(); //remove li of tab
    $('#myTab a:last').tab('show'); // Select first tab
    $(tabContentId).remove(); //remove respective tab content
}

function addChamadoTab(e) {

    if (typeof e.row === 'undefined') {
        var tabText = "Novo";
        var loadURL = "/Chamados/CreateOrEditModal/";
    } else {
        var tabText = e.row.data.id;
        var loadURL = "/Chamados/CreateOrEditModal/" + e.row.data.id;
    }


    var tabId = "compose" + composeCount; //this is id on tab content div where the 
    composeCount = composeCount + 1; //increment compose count

    $('.nav-tabs').append('<li class="nav-item"><a class="nav-link" href="#' + tabId + '"><button class="close closeTab" type="button" ><i class="fas fa-times"></i></button>' + tabText + '</a></li>');
    $('.tab-content').append('<div class="tab-pane" id="' + tabId + '"></div>');

    craeteNewTabAndLoadUrl("", loadURL, "#" + tabId);

    showTab(tabId);
    registerCloseEvent();
}

function cadastrarEditarChamado() {
    var _chamadoService = abp.services.app.chamado;
    var hash = $currentTab[0].hash;
    fm = getElement('form.formChamado');
    var chamado = fm.serializeFormToObject();
    abp.ui.setBusy();
    _chamadoService.createOrEdit(
        chamado
    ).done(function (result) {
        abp.notify.info("Salvo com sucesso!");
        gridChamadosInstance().refresh();
        craeteNewTabAndLoadUrl("", "/Chamados/CreateOrEditModal/" + result, hash);
        $('a[href*="' + hash + '"]').html('<button class="close closeTab" type="button" ><i class="fas fa-times"></i></button>' + result);
        registerCloseEvent();
    }).always(function () {
        abp.ui.clearBusy();
    });
}

function cancelarChamado(e) {
    var _chamadoService = abp.services.app.chamado;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('CancelConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _chamadoService.cancelar({
                    id: e.row.data.id
                }).done(function () {
                    gridChamadosInstance().refresh();
                    abp.notify.info(l('SuccessCanceled'));
                });
            }
        }
    );
}

function assumirChamado() {
    var _chamadoService = abp.services.app.chamado;
    var chamadoId = getElement('[name=id]').val();
    var hash = $currentTab[0].hash;
    fm = getElement('form.formChamado');
    var chamado = fm.serializeFormToObject();
    abp.ui.setBusy();
    _chamadoService.assumir(
        chamado
    ).done(function () {
        abp.notify.info("Salvo com sucesso!");
        gridChamadosInstance().refresh();
        craeteNewTabAndLoadUrl("", "/Chamados/CreateOrEditModal/" + chamadoId, hash);
    }).always(function () {
        abp.ui.clearBusy();
    });
}

function chamadosDblClick(e) {
    addChamadoTab(e);
}

function validateFormChamado(e) {
    e.component.validate();
}

function viewFilterChamados(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'GridStates/ViewGridStatesFiltersModal',
        scriptUrl: abp.appPath + 'view-resources/Views/GridStates/_GridStatesFiltersView.js',
        modalClass: 'GridStatesFiltersView'
    });
    _createOrEditModal.open({ tela: 'Chamados', state: JSON.stringify(gridChamadosInstance().state()) });
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
                dataGrid.state(null);
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

function gridChamadosInstance() {
    return $("#gridChamados").dxDataGrid("instance");
}

function gridReset() {
    gridChamadosInstance().state('{}');
}

function formatRow(e) {
    if (e.rowType == 'data') {
        if (e.data.status == 2) {
            e.rowElement.css('backgroundColor', '#E0E0E0');
        }
        if (e.data.status == 3) {
            e.rowElement.css('backgroundColor', '#ef5350');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
        }
    }
}

function comboClientesDisplayExpr(item) {
    return item && item.nomeFantasia + " (" + formatCNPJ(item.cpfCnpj) + ") " + item.razaoSocial;
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

function dDBClientesOnInitialized(e) {
    clienteFocus = e.component.option('value');
}

function dxComboClientesOnInitialized(e) {
    e.component.option("focusedRowKey", clienteFocus)
}

function showPopEmpresa(e) {
    var popEmpresa = getElement('.popempresa');
    popEmpresa.dxPopup({
        contentTemplate: function (contentElement) {
            var tabPanel = $("<div>");
            var scrollView = $("<div id='scrollView'></div>");
            scrollView.append(tabPanel);
            tabPanel.dxTabPanel({
                focusStateEnabled: false,
                items: [
                    {
                        title: 'Informações Gerais',
                        template: getClienteDetalhes(e, popEmpresa)
                    },
                    {
                        title: 'Equipamentos',
                        template: getEquipamentosCliente(e.row.data.id)
                    },
                    {
                        title: 'Contratos',
                        template: getContratosCliente(e.row.data.numeroERP)
                    }
                ]
            });
            scrollView.dxScrollView({
                height: '100%',
                width: '100%'

            });
            contentElement.append(scrollView)
            return contentElement;
        },
        showTitle: true,
        title: "Dados da Empresa",
        visible: true
    });
}

function getClienteDetalhes(e, popEmpresa) {
    return function () {

        var telefone = e.row.data.telefone;
        if (telefone.length > 10) {
            telefone = Inputmask.format(e.row.data.telefone, { alias: "(99) 99999-9999" })
        } else {
            telefone = Inputmask.format(e.row.data.telefone, { alias: "(99) 9999-9999" })
        }

        var endereco = e.row.data.enderecoRua + ", " + e.row.data.enderecoNumero + " - " + e.row.data.enderecoBairro + " (" + e.row.data.enderecoComplemento + ") " + "CEP: " + e.row.data.enderecoCep;

        var obs = e.row.data.clienteObs;
        if (e.row.data.clienteObs == null) {
            obs = 'Sem Observações';
        }

        return $("<div style='padding:20px;'>").dxForm({
            colCount: 12,
            labelLocation: "left",
            items: [
                {
                    dataField: "numeroERP",
                    colSpan: 4,
                    label: {
                        text: "Código ERP"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: e.row.data.numeroERP
                    }
                },
                {
                    dataField: "cpfCnpj",
                    colSpan: 8,
                    label: {
                        text: "CNPJ / CPF"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: formatCNPJ(e.row.data.cpfCnpj)
                    }
                },
                {
                    dataField: "nomeFantasia",
                    colSpan: 6,
                    label: {
                        text: "Nome Fantasia"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: e.row.data.nomeFantasia
                    }
                },
                {
                    dataField: "razaoSocial",
                    colSpan: 6,
                    label: {
                        text: "Razão Social"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: e.row.data.razaoSocial
                    }
                },
                {
                    dataField: "telefone",
                    colSpan: 6,
                    label: {
                        text: "Telefone"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: telefone
                    }
                },
                {
                    dataField: "contatoCliente",
                    colSpan: 6,
                    label: {
                        text: "Contato"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: e.row.data.contato
                    }
                },
                {
                    dataField: "email",
                    colSpan: 12,
                    label: {
                        text: "E-Mail"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: e.row.data.email
                    }
                },
                {
                    dataField: "isClienteMensalista",
                    colSpan: 6,
                    editorType: "dxSwitch",
                    label: {
                        text: "Mensalista"
                    },
                    editorOptions: {
                        readOnly: true,
                        switchedOnText: "SIM",
                        switchedOffText: "NÃO",
                        value: e.row.data.isClienteMensalista
                    }
                },
                {
                    dataField: "isClienteBloqueado",
                    colSpan: 6,
                    editorType: "dxSwitch",
                    label: {
                        text: "Bloqueado"
                    },
                    editorOptions: {
                        readOnly: true,
                        switchedOnText: "SIM",
                        switchedOffText: "NÃO",
                        value: e.row.data.isClienteBloqueado
                    }
                },
                {
                    dataField: "endereco",
                    colSpan: 12,
                    label: {
                        text: "Endereço"
                    },
                    editorOptions: {
                        readOnly: true,
                        value: endereco
                    }
                },
                {
                    dataField: "obs",
                    colSpan: 12,
                    editorType: "dxTextArea",
                    label: {
                        text: "Observações"
                    },
                    editorOptions: {
                        readOnly: true,
                        height: 200,
                        value: obs
                    }
                },
                {
                    itemType: "button",
                    horizontalAlignment: "right",
                    colSpan: 12,
                    buttonOptions: {
                        text: "Editar Cliente",
                        stylingMode: "outlined",
                        type: "default",
                        onClick: function () {
                            popEmpresa.dxPopup("instance").hide();
                            getElement('.dropDownBoxClientes').dxDropDownBox("instance").close();
                            var _createOrEditModal = new app.ModalManager({
                                viewUrl: abp.appPath + 'Clientes/CreateOrEditModal',
                                scriptUrl: abp.appPath + 'view-resources/Views/Clientes/_CreateOrEditModal.js',
                                modalClass: 'CreateOrEditModalCliente',
                                modalSize: 'modal-lg modal-fluid modal-full-height modal-dialog-scrollable'
                            });
                            _createOrEditModal.open({ id: e.row.data.id });
                        }
                    }
                }
            ]
        });
    };
}

function getEquipamentosCliente(clienteId) {
    return function () {
        var dataSource = new DevExpress.data.DataSource({
            store: DevExpress.data.AspNet.createStore({
                key: "id",
                loadUrl: "/Equipamentos/GetAllEquipamentos"
            }),
            filter: ["clienteId", "=", clienteId]
        });
        return $("<div>").dxDataGrid({
            dataSource: dataSource,
            showBorders: true,
            filterRow: {
                visible: false
            },
            groupPanel: {
                visible: false
            },
            headerFilter: {
                visible: false,
                allowSearch: false
            },
            columnChooser: {
                enabled: false
            },
            columns: [{
                caption: "Número de Série",
                dataField: "descricao"
            }, {
                caption: "Modelo",
                dataField: "modeloFkDescricao"
            }, {
                caption: "Inativo",
                dataField: "inativo"
            }]
        });
    };
}

function getContratosCliente(numeroERP) {
    return function () {
        var dataSource = new DevExpress.data.DataSource({
            store: DevExpress.data.AspNet.createStore({
                key: "id",
                loadUrl: "/Clientes/GetContratosCliente"
            }),
            filter: ["numeroERP", "=", numeroERP]
        });
        return $("<div>").dxDataGrid({
            dataSource: dataSource,
            showBorders: true,
            filterRow: {
                visible: false
            },
            groupPanel: {
                visible: false
            },
            headerFilter: {
                visible: false,
                allowSearch: false
            },
            columnChooser: {
                enabled: false
            },
            columns: [{
                caption: "Contrato",
                dataField: "descricao"
            }, {
                caption: "Quantidade",
                dataField: "quantidade"
            }]
        });
    };
}

function changeComboProdutos(e) {
    var grupoBox = getElement('.grupoId').dxSelectBox("instance");
    grupoBox.option('value', null);
    grupoBox.option('disabled', false);
    grupoBox.getDataSource().filter(["produtoId", "=", e.value]);
    grupoBox.getDataSource().reload();
}

function changeComboGrupos(e) {
    var subGrupoBox = getElement('.subGrupoId').dxSelectBox("instance");
    subGrupoBox.option('value', null);
    subGrupoBox.option('disabled', false);
    if (e.value !== null) {
        subGrupoBox.getDataSource().filter(["grupoId", "=", e.value]);
    }
    subGrupoBox.getDataSource().reload();
}

function classificacaoChanged(e) {
    if (e.selectedItem.id == 3) {
        var ocorrencia = getElement('.ocorrencia').dxTextArea("instance");
        if (ocorrencia.option('value') == null) {
            var impPreTxt = "DADOS CLIENTE \nContato da pessoa que irá utilizar o sistema EPM: \nTelefone: \nE-mail: \nResponsável pelo T.I da empresa: \nEndereço para implantação presencial (quando presencial): \n\nPLANO CONTRATADO \nN° FUNCIONÁRIOS: \nN° MOBILE: \nFACIAL: \nQR CODE: \nEQUIPAMENTO: \n\nDADOS CONTABILIDADE \nEscritório contábil: \nPessoa responsável pela folha de pagamento: \nTelefone: \nE-mail:";
            ocorrencia.option('height', 300);
            ocorrencia.option('value', impPreTxt);
        }
    }
    e.component.option('hint', e.selectedItem.observacao);
}

function slaChanged(e) {
    var slaDtVto = getElement('.slaDataVencimento').dxDateBox("instance");
    if (e.selectedItem.id !== 4 && slaDtVto.option('value') == null) {
        slaDtVto.option('disabled', true);
        var d = new Date();
        var sla = e.selectedItem.duracao;
        var a = sla.split(':');
        d.setMinutes(d.getMinutes() + (+a[0] * 60 + +a[1]));
        slaDtVto.option('value', d);
    } else {
        slaDtVto.option('disabled', false);
    }
}


/* Followups */

function dxGridFollowupGetInstance() {
    var tabElement = getElement('.gridFollowup');
    return tabElement.dxDataGrid("instance");
}

function onToolbarFollowupsPreparing(e) {
    var chamadoStatus = getElement('[name=status]');
    if (chamadoStatus.val() == 1) {
        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                icon: "add",
                text: "",
                type: "default",
                onClick: function () {
                    var chamadoId = getElement('[name=id]');
                    cadastrarFollowupModal(chamadoId.val());
                }
            }
        });
    }
}

function cadastrarFollowupModal(chamadoId) {
    var _createOrEditModalFollowup = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalFollowup',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalFollowup.js',
        modalClass: 'CreateOrEditModalFollowup'
    });
    _createOrEditModalFollowup.open({ chamadoId: chamadoId });
}

function editarFollowupModal(e) {
    if (e.row.data.followupFkCancelado == true) {
        abp.message.warn('', 'O followup está cancelado, não pode ser editado!');
    } else if (abp.session.userId != e.row.data.followupFkUsuarioId) {
        abp.message.warn('', 'O followup só pode ser editado por seu criador, se precisar, crie um novo!');
    } else {
        var _createOrEditModalFollowup = new app.ModalManager({
            viewUrl: abp.appPath + 'Chamados/CreateOrEditModalFollowup',
            scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalFollowup.js',
            modalClass: 'CreateOrEditModalFollowup'
        });
        _createOrEditModalFollowup.open({ id: e.row.data.id, chamadoId: e.row.data.chamadoId });
    }
}

function cancelarFollowup(e) {
    if (abp.session.userId != e.row.data.followupFkUsuarioId) {
        abp.message.warn('', 'O followup só pode ser cancelado por seu criador, se precisar, crie um novo!');
    } else {
        var _followupService = abp.services.app.followup;
        var l = abp.localization.getSource('Suporte');
        abp.message.confirm(
            '',
            l('CancelConfirm'),
            function (isConfirmed) {
                if (isConfirmed) {
                    _followupService.cancelar({
                        id: e.row.data.id
                    }).done(function () {
                        dxGridFollowupGetInstance().refresh();
                        abp.notify.info(l('SuccessCanceled'));
                    });
                }
            }
        );
    }
}

function transferirChamadoChanged(e) {
    var formFollowup = $('#formFollowup').dxForm('instance');
    if (e.value == true) {
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "visible", true);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "isRequired", true);
        formFollowup.validate();
    } else {
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "visible", false);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "isRequired", false);
        formFollowup.validate();
    }
}

function sbFollowupTipoChanged(e) {
    var formFollowup = $('#formFollowup').dxForm('instance');
    if (e.value == 2) {
        formFollowup.itemOption("grupo.transferirChamadoItem", "visible", false);
        formFollowup.itemOption("grupo.eventoFollowupItem", "visible", false);
        formFollowup.itemOption("grupo.eventoFollowupItem", "isRequired", false);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "visible", true);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "isRequired", true);
        formFollowup.validate();
    } else if (e.value == 3) {
        formFollowup.itemOption("grupo.transferirChamadoItem", "visible", true);
        formFollowup.itemOption("grupo.eventoFollowupItem", "visible", true);
        formFollowup.itemOption("grupo.eventoFollowupItem", "isRequired", true);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "visible", false);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "isRequired", false);
        //console.log(formFollowup);
        //$('#eventoFollowupId').dxSwitch('instance').option("value", false);
        formFollowup.validate();
    } else {
        formFollowup.itemOption("grupo.transferirChamadoItem", "visible", false);
        formFollowup.itemOption("grupo.eventoFollowupItem", "visible", false);
        formFollowup.itemOption("grupo.eventoFollowupItem", "isRequired", false);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "visible", false);
        formFollowup.itemOption("grupo.usuarioTransferenciaItem", "isRequired", false);
        formFollowup.validate();
    }
}

function followupOnFormReady(e) {
    var tipo = e.component.option("formData").Followup.Tipo;
    if (tipo == 3) {
        e.component.itemOption("grupo.transferirChamadoItem", "visible", true);
        e.component.itemOption("grupo.eventoFollowupItem", "visible", true);
        e.component.itemOption("grupo.eventoFollowupItem", "isRequired", true);
    }
    if (tipo == 2) {
        e.component.itemOption("grupo.usuarioTransferenciaItem", "visible", true);
    } else {
        e.component.itemOption("grupo.usuarioTransferenciaItem", "visible", false);
    }
}

function formatRowFollowup(e) {
    if (e.rowType == 'data') {
        if (e.data.followupFkTipo == 2) {
            e.rowElement.css('backgroundColor', '#BDBDBD');
            e.rowElement.addClass('bt-branco');
        }
        if (e.data.followupFkCancelado == true) {
            e.rowElement.css('backgroundColor', '#ef5350');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
        }
    }
}


/* Tarefas */

function dxGridTarefasGetInstance() {
    var tabElement = getElement('.gridTarefas');
    return tabElement.dxDataGrid("instance");
}

function tarefasDblClick(e) {
    editarTarefaModal(e);
}

function onToolbarTarefasPreparing(e) {
    var chamadoStatus = getElement('[name=status]');
    if (chamadoStatus.val() == 1) {
        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                icon: "add",
                text: "",
                type: "default",
                onClick: function () {
                    var chamadoId = getElement('[name=id]');
                    cadastrarTarefaModal(chamadoId.val());
                }
            }
        });
    }
}

function cadastrarTarefaModal(chamadoId) {
    var _createOrEditModalTarefa = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalTarefa',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalTarefa.js',
        modalClass: 'CreateOrEditModalTarefa'
    });
    _createOrEditModalTarefa.open({ chamadoId: chamadoId });
}

function editarTarefaModal(e) {
    var _createOrEditModalTarefa = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalTarefa',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalTarefa.js',
        modalClass: 'CreateOrEditModalTarefa'
    });
    _createOrEditModalTarefa.open({ id: e.row.data.id, chamadoId: e.row.data.chamadoId });
}

function cancelarTarefa(e) {
    var _tarefaService = abp.services.app.tarefa;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('CancelConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _tarefaService.cancelar({
                    id: e.row.data.id
                }).done(function () {
                    dxGridTarefasGetInstance().refresh();
                    abp.notify.info(l('SuccessCanceled'));
                });
            }
        }
    );
}

function formatRowTarefas(e) {
    if (e.rowType == 'data') {
        if (e.data.status == true) {
            e.rowElement.css('backgroundColor', '#A5D6A7');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
        }
        if (e.data.cancelada == true) {
            e.rowElement.css('backgroundColor', '#ef5350');
            e.rowElement.css('color', '#ffffff');
            e.rowElement.addClass('bt-branco');
        }
    }
}

/* Implantação */

function dxGridImplantacaoGetInstance() {
    var tabElement = getElement('.gridImplantacao');
    return tabElement.dxDataGrid("instance");
}

function editarEtapaChamadoModal(e) {
    if (e.row.data.etapaStatusId === 1) {
        abp.message.warn('', 'Esta etapa já está concluída!');
        return;
    }
    var _createOrEditModalEtapaChamado = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalEtapaChamado',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalImplantacao.js',
        modalClass: 'CreateOrEditModalImplantacao'
    });
    _createOrEditModalEtapaChamado.open({ id: e.row.data.id, chamadoId: e.row.data.chamadoId });
}

function recusarEtapaChamadoModal(e) {
    if (e.row.data.etapaStatusId === 1) {
        abp.message.warn('', 'Esta etapa já está concluída!');
        return;
    } else if (e.row.data.etapaStatusId === 2) {
        abp.message.warn('Somente etapas pendentes de aprovação podem ser reprovadas.', 'Esta etapa já está em andamento!');
        return;
    }
    var _createOrEditModalEtapaChamado = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/RecusarEtapaChamado',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_RecusarEtapaModal.js',
        modalClass: 'RecusarEtapaModal'
    });
    _createOrEditModalEtapaChamado.open({ id: e.row.data.id, chamadoId: e.row.data.chamadoId });
}

function aprovarConcluirEtapa(e) {
    var _implantacaoService = abp.services.app.implantacao;
    var title = "";
    var text = "";
    var sucesso = "";
    if (e.row.data.etapaStatusId === 1) {
        abp.message.warn('', 'Esta etapa já está concluída!');
        return;
    } else if (e.row.data.etapaStatusId === 2) {
        title = "Deseja Concluir sua etapa?";
        text = "Isso fará com que a etapa passe para aprovação do próximo responsável";
        sucesso = "Etapa pendente de aprovação!";
    } else if (e.row.data.etapaStatusId === 3) {
        title = "Deseja Aprovar a etapa?";
        text = "Isso fará com que a etapa passe para o status de concluída";
        sucesso = "Etapa concluída com sucesso!";
    }
    abp.message.confirm(
        text,
        title,
        function (isConfirmed) {
            if (isConfirmed) {
                _implantacaoService.aprovarConcluirEtapa({
                    id: e.row.data.id
                }).done(function () {
                    dxGridImplantacaoGetInstance().refresh();
                    abp.notify.info(sucesso);
                });
            }
        }
    );
}

function formatRowImplantacao(e) {
    if (e.rowType == 'data') {
        if (e.data.etapaStatusId === 1) {
            e.rowElement.css('backgroundColor', '#81C784');
            e.rowElement.css('color', '#fff');
            e.rowElement.addClass('bt-branco');
        } else if (e.data.etapaStatusId === 3) {
            e.rowElement.css('backgroundColor', '#FFC107');
            e.rowElement.css('color', '#fff');
            e.rowElement.addClass('bt-branco');
        } else if (e.data.etapaStatusId === 4) {
            e.rowElement.css('backgroundColor', '#ef5350');
            e.rowElement.css('color', '#fff');
            e.rowElement.addClass('bt-branco');
        }
    }
}

/* Assistencia */

function addAssistencia(e) {
    var chamadoId = getElement('[name=id]');
    var _createOrEditModalAssistencia = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalAssistencia',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalAssistencia.js',
        modalClass: 'CreateOrEditModalAssistencia'
    });
    _createOrEditModalAssistencia.open({ chamadoId: chamadoId.val() });
}

function editAssistencia(e) {
    var chamadoId = getElement('[name=id]');
    var assistenciaId = getElement('[name=assistencia_id]');
    var _createOrEditModalAssistencia = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalAssistencia',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalAssistencia.js',
        modalClass: 'CreateOrEditModalAssistencia'
    });
    _createOrEditModalAssistencia.open({ id: assistenciaId.val(), chamadoId: chamadoId.val() });
}

/* Anexos */

function dxGridAnexoGetInstance() {
    var tabElement = getElement('.gridAnexos');
    return tabElement.dxDataGrid("instance");
}

function onToolbarAnexosPreparing(e) {
    var chamadoStatus = getElement('[name=status]');
    if (chamadoStatus.val() == 1) {
        e.toolbarOptions.items.unshift({
            location: "after",
            widget: "dxButton",
            options: {
                icon: "add",
                text: "",
                type: "default",
                onClick: function () {
                    var chamadoId = getElement('[name=id]');
                    cadastrarAnexoModal(chamadoId.val());
                }
            }
        });
    }
}

function cadastrarAnexoModal(chamadoId) {
    var _createOrEditModalAnexo = new app.ModalManager({
        viewUrl: abp.appPath + 'Chamados/CreateOrEditModalAnexo',
        scriptUrl: abp.appPath + 'view-resources/Views/Chamados/_CreateOrEditModalAnexo.js',
        modalClass: 'CreateOrEditModalAnexo'
    });
    _createOrEditModalAnexo.open({ chamadoId: chamadoId });
}

function excluirAnexo(e) {
    if (abp.session.userId != e.row.data.usuarioId) {
        abp.message.warn('', 'Somente quem fez o upload pode deletar o mesmo!');
        return;
    }
    abp.message.confirm(
        'Esta ação não poderá ser revertida!',
        'Tem certeza que deseja deletar este Anexo?',
        function (isConfirmed) {
            if (isConfirmed) {
                abp.ajax({
                    type: "GET",
                    url: '/Chamados/DeletarAnexo',
                    data: { id: e.row.data.id, caminho: e.row.data.caminho },
                }).done(function (data) {
                    abp.notify.success(data.mensagem);
                    dxGridAnexoGetInstance().refresh();
                });
            }
        }
    );
}

function viewArquivo(e) {
    window.open(
        '/arquivos/chamado/' + e.row.data.caminho,
        '_blank'
    );
}

function downloadArquivo(e) {
    window.open("/Chamados/ForceDownload/?link=" + e.row.data.caminho + "&output=" + e.row.data.nome);
}

function editChamadoExterno(e) {
    window.open(
        '/Chamados/Editar/' + e.row.data.chamadoId,
        '_blank'
    );
}
