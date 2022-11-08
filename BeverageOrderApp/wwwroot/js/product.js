
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
                { "data": "name", "widt": "15%" },
                {
                    "data": "id",
                    "render": function (data) {
                        return `
                            <div class="w-35 btn-group" role="group" >
                                <a href="/Admin/Product/Edit?id=${data}"
                                   class="btn btn-primary mx-2">  <i class="bi bi-pencil-square"></i>Update </a>
                                     <a class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i>Delete</a>
                            </div>

                           `
                        
                    }
                }
            ]
        });
    }




