using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Areas.Admin.Models.EditModels;


public class CreateSlide
{
    [Required(ErrorMessage = "Vui lòng nhập tên slide")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Đường dẫn cho slide là bắt buộc")]
    public string Link { get; set; }

    [Required(ErrorMessage = "Hãy nhập thứ tự slide xuất hiện")]
    [Range(0, int.MaxValue, ErrorMessage = "Số lượng sản phẩm không đúng")]
    public int Sort { get; set; }
}