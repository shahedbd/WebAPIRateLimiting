
var DeleteDepartment = function (id) {
    Swal.fire({
        title: 'Do you want to delete this item?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            var _BaseUrlAPIProj = BaseUrlAPIProj();
            $.ajax({
                type: "DELETE",
                //url: _BaseUrlAPIProj[0] + "Department/DeleteDepartment/" + id,
                url: "Department/DeleteConfirmed/" + id,
                success: function (result) {
                    var message = "Department has been deleted successfully";
                    Swal.fire({
                        title: message,
                        icon: 'info',
                        onAfterClose: () => {
                            location.reload();
                        }
                    });
                }
            });
        }
    });
};