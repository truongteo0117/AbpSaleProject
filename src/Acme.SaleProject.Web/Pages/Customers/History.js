$(function () {
    var l = abp.localization.getResource('SaleProject');
    var viewMore = new abp.ModalManager(abp.appPath + 'Customers/ViewMore');
    var dataTable = $('#HistoryTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.saleProject.customers.history.getList),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Number Phone'),
                    data: "numberPhone"
                },
                {
                    title: l('Customer Status'),
                    data: "status",
                    render: function (data) {
                        return l('Enum:CustomerStatus.' + data);
                    }
                },
                {
                    title: l('Product Name'),
                    data: "productName"
                },
                {
                    title: l('ProcessBy'),
                    data: "processBy"
                },
                {
                    title: l('Total Amount ($)'),
                    data: "totalAmount"
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
                                    text: l('View More'),
                                    action: function (data) {
                                        viewMore.open({ id: data.record.id });
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
                                        acme.saleProject.customers.history
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
});
