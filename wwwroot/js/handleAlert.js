function handleDeleteAlert({ id, icon, title, message, confirmTitle }) {
    Swal.fire({
        title: title || "Delete ?",
        text: message || 'You won\'t be able to revert this!',
        icon: icon || 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: confirmTitle || 'Yes!',
        cancelButtonText: 'Cancel'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/Admin/PhoneCategories/Delete/${id}`).then(() => {
                Swal.fire(
                    'Deleted!',
                    'Deleted Successfully!',
                    'success'
                ).then(() => {
                    window.location.href = "/Admin/PhoneCategories";
                })
            });
        }
    });
    return false;
}