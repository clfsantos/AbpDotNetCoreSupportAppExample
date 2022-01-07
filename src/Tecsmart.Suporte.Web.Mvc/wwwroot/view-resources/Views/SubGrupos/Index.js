(function ($) {
    abp.event.on('subGrupo.createoredit', function () {
        gridSubGruposGetInstance().refresh();
    });
})(jQuery);

function gridSubGruposGetInstance() {
    return $('#gridSubGrupos').dxDataGrid('instance');
}

function addSubGrupo() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'SubGrupos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/SubGrupos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalSubGrupo'
    });
    _createOrEditModal.open();
}

function editSubGrupo(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'SubGrupos/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/SubGrupos/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalSubGrupo'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function deleteSubGrupo(e) {
    var _subGrupoService = abp.services.app.subGrupo;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _subGrupoService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridSubGruposGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
