function handleDeleteAlert({ id, icon, title, message, confirmTitle }) {
    Swal.fire({
        title: title || "Xóa ?",
        text: message || 'Bạn chắc chắn muốn xóa ?. Nó sẽ bị xóa vĩnh viễn!',
        icon: icon || 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: confirmTitle || 'Đồng ý',
        cancelButtonText: 'Thoát'
    }).then((result) => {
        if (result.isConfirmed) {
            fetch(`/Admin/ProductCategories/Delete/${id}`).then(() => {
                Swal.fire(
                    'Đã xóa!',
                    'Xóa thành công!',
                    'success'
                ).then(() => {
                    window.location.href = "/Admin/ProductCategories";
                })
            });
        }
    });
    return false;
}