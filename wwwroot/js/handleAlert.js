function handleDeleteAlert({ icon, title, message, confirmTitle, deleteLink, redirectLink = "/Admin" }) {
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
            fetch(deleteLink).then(() => {
                Swal.fire(
                    'Đã xóa!',
                    'Xóa thành công!',
                    'success'
                ).then(() => {
                    window.location.href = redirectLink;
                })
            });
        }
    });
    return false;
}