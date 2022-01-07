(function ($) {
    abp.event.on('release.createoredit', function () {
        gridReleasesGetInstance().refresh();
    });
})(jQuery);

function gridReleasesGetInstance() {
    return $('#gridReleases').dxDataGrid('instance');
}

function novoRelease() {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Versoes/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Versoes/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalRelease'
    });
    _createOrEditModal.open();
}

function editarRelease(e) {
    var _createOrEditModal = new app.ModalManager({
        viewUrl: abp.appPath + 'Versoes/CreateOrEditModal',
        scriptUrl: abp.appPath + 'view-resources/Views/Versoes/_CreateOrEditModal.js',
        modalClass: 'CreateOrEditModalRelease'
    });
    _createOrEditModal.open({ id: e.row.data.id });
}

function excluirRelease(e) {
    var _releaseService = abp.services.app.release;
    var l = abp.localization.getSource('Suporte');
    abp.message.confirm(
        '',
        l('DeleteConfirm'),
        function (isConfirmed) {
            if (isConfirmed) {
                _releaseService.delete({
                    id: e.row.data.id
                }).done(function () {
                    gridReleasesGetInstance().refresh();
                    abp.notify.info(l('SuccessfullyDeleted'));
                });
            }
        }
    );
}
