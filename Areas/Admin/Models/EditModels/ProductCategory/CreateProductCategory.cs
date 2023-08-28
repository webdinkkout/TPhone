using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Areas.Admin.Models.EditModels;

public class CreateProductCategory
{
    [Required(ErrorMessage = "Vui lòng nhập tên danh mục!")]
    public string Name { get; set; }

}