
var dataTable;
    $(document).ready(function () {
        loadDataTable();
    });
    function loadDataTable() {
        dataTable = $('#tblData').DataTable({
            "ajax": {
                "url": "/Admin/Product/GetAll",
                "type": "GET",
                "datatype": "json"
            },
            "columns": [
                { "data": "name", "widt": "15%" }
                //{ "data": "beverageTyp.name", "widt": "15%" }
            ]
        });
    }




