(function ($) {
    abp.event.on('grupo.createoredit', function () {
        gridGruposGetInstance().refresh();
    });
})(jQuery);

function gridGruposGetInstance() {
    return $('#gridGrupos').dxDataGrid('instance');
}

function addGrupo() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Grupos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Grupos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalGrupo'
    });
    _createOrEditModal.open();
}

function editGrupo(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Grupos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Grupos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalGrupo'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteGrupo(e) {
    var _grupoService = abp.services.app.grupo;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _grupoService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridGruposGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
