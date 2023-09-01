$(document).ready(function () {
    getAllProduct();

    const txtSearchProduct = document.getElementById("txtSearchProduct");
    var delayTimer;
    txtSearchProduct.oninput = function (e) {
        const categoryId = $("#ddlCategory").val();
        const brandId = $("#ddlBrand").val();
        const supplierId = $("#ddlSupplier").val();
        const searchKey = txtSearchProduct.value;
        clearTimeout(delayTimer);
        delayTimer = setTimeout(function () {
            getAllProduct(categoryId, brandId, supplierId, searchKey);
        }, 700);
    }

    $("#ddlCategory, #ddlBrand, #ddlSupplier").on("change", function () {
        const categoryId = $("#ddlCategory").val();
        const brandId = $("#ddlBrand").val();
        const supplierId = $("#ddlSupplier").val();
        const searchKey = txtSearchProduct.value;

        getAllProduct(categoryId, brandId, supplierId, searchKey);
    });

})

const getAllProduct = (categoryId, brandId, supplierId, key = "") => {
    $.ajax({
        type: "GET",
        url: `/Admin/Product/GetAllProduct?name=${key}&categoryId=${categoryId}&brandId=${brandId}&supplierId${supplierId}`,

        success: function (res) {
            let htmlResult = "";

            if (res.length <= 0) {
                htmlResult += `
                
                <tr>
                    <td colspan="6">
                        Danh sách rỗng 	&nbsp;	&nbsp;
                        <a href="/Admin/Product/Create" class="btn btn-success">
                            <i class="bi bi-plus-circle"></i>
                            Tạo sản phẩm mới ?</a>
                    </td>
                </tr>
                
                `
            }

            res.forEach((item) => {
                htmlResult += `
                    <tr>
                        <th style="line-height: 48px" scope="row">${item.id}</th>
                        <td style="line-height: 48px" >${item.productName}</td>
                        <td style="line-height: 48px" >${handleConvertNumberToMoney(item.price, "VND")}</td>
                        <td style="line-height: 48px" >${handleConvertNumberToMoney(item.quantity)}</td>
                        <td >
                            <img class="img-fluid" style="width: 48px;height: 48px;object-fit: cover;object-position: center;" src="${item.thumbnailFilePath}" alt="${item.seoName}">
                        </td>
                        <td style="line-height: 48px">
                            <a class="btn btn-danger" data-id="${item.id}" onclick="deleteProduct(${item.id})">
                                <i class="bi bi-x-circle"></i>
                                Xóa
                            </a>
                            <a  asp-action="Edit"  asp-route-id="${item.id}" class="btn btn-primary">
                                <i class="bi bi-pencil-square"></i>
                                Chỉnh sửa</a>
                        </td>
                    </tr>
                `
            })
            $("#tblProducts").html(htmlResult);
        },
        error: function (err) {
        }
    })
}

const deleteProduct = (idProduct) => {

    Swal.fire({
        title: "Xóa ?",
        text: 'Bạn chắc chắn xóa sản phẩm này chứ. Nó sẽ bị xóa vĩnh viễn',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Đồng ý!',
        cancelButtonText: 'Thoát'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "GET",
                url: `/Admin/Product/Delete?id=${idProduct}`,
                success: function (res) {
                    const categoryId = $("#ddlCategory").val();
                    const brandId = $("#ddlBrand").val();
                    const supplierId = $("#ddlSupplier").val();
                    const searchKey = txtSearchProduct.value;
                    getAllProduct(categoryId, brandId, supplierId, searchKey);
                    Swal.fire(
                        'Đã xóa!',
                        'Xóa thành công!',
                        'success'
                    )
                },
                error: function (err) {
                    Swal.fire(
                        'Xóa thất bại!',
                        'Xóa thất bại vui lòng thử lại!',
                        'error'
                    )
                }
            })
        }
    });


}