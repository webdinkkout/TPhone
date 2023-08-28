using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Areas.Admin.Models.EditModels;

public class EditProductCategory
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên danh mục")]
    public string Name { get; set; }
    public string? ThumbnailFilePath { get; set; }
}