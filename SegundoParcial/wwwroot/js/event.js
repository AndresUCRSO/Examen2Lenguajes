var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Event/GetAll"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "maxAssistance", "width": "25%" },
            { "data": "price", "width": "25%" },
            {
                "data": "id",
                "render": function (data) {
                    return `

                            <div class="btn-group role="group" w-75">
                            <a href="/Admin/Event/Upsert?id=${data}" class="btn btn-primary">
							<i class="bi bi-pencil-square"></i>Edit</a>
							<a onClick="Delete('/Admin/Event/Delete/${data}')" class="btn btn-danger">
							<i class="bi bi-trash"></i>Delete</a>
                            </div>

                            `
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(_url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: _url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}