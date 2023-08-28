# CellPhoneS Project

## Cấu trúc thư mục dự án

![](https://github.com/TaiLe1101/HostImg/blob/main/Screenshot%20from%202023-08-27%2023-49-11.png?raw=true)

## Chức năng từng thư mục và từng file

### Tập tin (File)

- `appsettings.json` khi clone dự án về sẽ không có phải tự tạo và copy nội dung của file `appsettings.Development.json` và dán vào file vừa tạo

### Thư mục (Directory)

#### Areas

![](https://github.com/TaiLe1101/HostImg/blob/main/Screenshot%20from%202023-08-28%2000-01-45.png?raw=true)

> Là thư mục chứa các bộ phận khác của website ví dụ `Admin`, ... sẽ có cấu tạo `MVC` tương tự như `Project` chính

#### Controllers

> Là thư mục sẽ chạy vào đầu tiên khi chúng ta vào trang web hay còn gọi là `Đều hướng trang`

#### Models

> Là thư mục chứ các `Domain Model (Entity)` hay còn gọi `Model` ánh xạ xuống cơ sở dữ liệu gần như `100%` và còn chứ thêm 2 thư mục nữa là `ViewModels` và `EditModel`

- `ViewModels` là thư mục đảm nhiệm chức năng quy định các thuộc tính được phép hiển thị ở `View`

##### Ví dụ:

```C#

// CategoryViewModel.cs
namespace CellPhoneS.Areas.Admin.Models.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SeoName { get; set; }

    public string? ThumbnailFilePath { get; set; }

    public CategoryViewModel(int Id, string Name, string SeoName, string ThumbnailFilePath = "")
    {
        this.Id = Id;
        this.Name = Name;
        this.ThumbnailFilePath = ThumbnailFilePath;
        this.SeoName = SeoName;
    }
}

```

- Còn `EditModels` có chức năng Nhận và gửi dữ liệu cũng như là kiểm tra dữ liệu hợp lệ `(Validate value)`

##### Ví dụ:

```C#
// CreeateProductCategory.cs

using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Areas.Admin.Models.EditModels;

public class CreateProductCategory
{
    [Required(ErrorMessage = "Vui lòng nhập tên danh mục!")]
    public string Name { get; set; }
}

```

- Cách sử dụng:

```C#

//File Controllers

[HttpGet("Admin/ProductCategories")]
public IActionResult Index()
{
    var categoriesViewModel = new List<CategoryViewModel>(); //Tạo 1 danh sách view model để trả về cho view | có thể là 1 đối tượng không nhất thiết phải là danh sách

    var categoriesRes = this.productCategoryService.FindAll(); // Lấy danh sách từ cơ sử dữ liệu (Database)

    // Công đoạn chuyển từ Model sang ViewModel(Mapping Values)
    foreach (var item in categoriesRes)
    {
        categoriesViewModel.Add(new CategoryViewModel(item.Id, item.Name, item.ThumbnailFilePath)); // Sử dụng phương thức(Method) `Add` để Thêm các ViewModel và danh sách ViewModel
    }

    return View(categoriesViewModel); // Trả Danh sách đã đươc chuyển đổi về View
}

```

```C#

// View
@model List<CategoryViewModel> // Sử dụng ở đây

@{
     ViewData["Title"] = "Product Categories";
    Layout = "_LayoutAdmin";
}

<div class="container">
    <section class="text-center">
        <h2>Categories</h2>
        <hr>
        <div class="mt-4">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Tên danh mục</th>
                        <th scope="col" >Chức năng</th>
                    </tr>
                </thead>
                <tbody>
                    @if(Model.Count() <= 0) {
                        <tr>
                            <td colspan="3">
                                Danh sách rỗng 	&nbsp;	&nbsp;
                                <a asp-action="Create" class="btn btn-success">
                                    <i class="bi bi-plus-circle"></i>
                                    Tạo danh mục mới ?</a>
                            </td>
                        </tr>
                    }else {
                        @foreach(var item in Model) {
                            <tr>
                                <th scope="row">@item.Id</th>
                                <td>@item.Name</td>
                                <td>
                                    <a asp-action="Delete" asp-route-id="@item.Id" class="btn btn-danger" onclick="return handleDeleteAlert({id: @item.Id})">
                                        <i class="bi bi-x-circle"></i>
                                        Delete
                                    </a>
                                    <a  asp-action="Edit"  asp-route-id="@item.Id" class="btn btn-primary">
                                        <i class="bi bi-pencil-square"></i>
                                        Edit</a>
                                </td>
                            </tr>
                        }
                    }
                </tbody>
            </table>
        </div>
    </section>
</div>

@section Scripts {
     <partial name="_HandleAlert" />
}

```
