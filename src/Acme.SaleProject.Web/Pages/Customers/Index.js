$(function () {
    var l = abp.localization.getResource('SaleProject');
    var createModal = new abp.ModalManager(abp.appPath + 'Customers/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Customers/EditModal');
    var orderModal = new abp.ModalManager(abp.appPath + 'Customers/Order');
    var importExcelModal = new abp.ModalManager(abp.appPath + 'Customers/ExcelModal');

    var dataTable = $('#CustomersTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.saleProject.customers.customer.getList),
            columnDefs: [            
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Customer Status'),
                    data: "status",
                    render: function (data) {
                        return l('Enum:CustomerStatus.' + data);
                    }
                },
                {
                    title: l('Number Phone'),
                    data: "numberPhone",
                },
                {
                    title: l('Address'),
                    data: "address"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                },
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Update Profile'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Order'),
                                    action: function (data) {
                                        orderModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'CustomerDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.saleProject.customers.customer
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                }
            ]
        })
    );
    createModal.onResult(function () {
        abp.notify.info(l('SuccessfullyCreated'));
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        abp.notify.info(l('SuccessfullyUpdated'));
        dataTable.ajax.reload();
    });
    importExcelModal.onResult(function () {
        abp.notify.info(l('SuccessfullyImported'));
        dataTable.ajax.reload();
    });
    $('#NewCustomerButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
    $('#ImportExcel').click(function (e) {
        importExcelModal.open();
    });
});
