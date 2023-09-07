using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Areas.Admin.Models.EditModels.Menu;

public class CreateMenu
{
    [Required(ErrorMessage = "Vui lòng nhập trường này")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập trường này")]
    public string Description { get; set; }

    public int Position { get; set; }
}