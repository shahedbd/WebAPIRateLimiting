
var DeleteBranch = function (id) {
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
                //url: _BaseUrlAPIProj[0] + "Branch/DeleteBranch/" + id,
                url: "Branches/DeleteConfirmed/" + id,
                success: function (result) {
                    var message = "Branch has been deleted successfully.";
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