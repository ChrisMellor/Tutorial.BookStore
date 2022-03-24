$(function () {
    var L = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Books/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Books/EditModal');

    var dataTable = $('#BooksTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(tutorial.bookStore.books.book.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items: [
                            {
                                text: L('Edit'),
                                visable: abp.auth.isGranted('BookStore.Books.Edit'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: L('Delete'),
                                visable: abp.auth.isGranted('BookStore.Books.Delete'),
                                confirmMessage: function (data) {
                                    return L('BookDeletionConfirmationMessage', data.record.name);
                                },
                                action: function (data) {
                                    tutorial.bookStore.books.book
                                        .delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(L('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                    }
                },
                {
                    title: L('Name'),
                    data: "name"
                },
                {
                    title: L('Author'),
                    data: "authorName"
                },
                {
                    title: L('Type'),
                    data: "type",
                    render: function (data) {
                        return L('Enum:BookType:' + data);
                    }
                },
                {
                    title: L('PublishDate'),
                    data: "publishDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: L('Price'),
                    data: "price"
                },
                {
                    title: L('CreationTime'), data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewBookButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});