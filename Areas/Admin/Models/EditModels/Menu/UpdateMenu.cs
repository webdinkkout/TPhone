using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Areas.Admin.Models.EditModels.Menu;

public class UpdateMenu
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập trường này")]
    public string Title { get; set; }

    public string Alias { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập trường này")]
    public string Description { get; set; }

    public int Position { get; set; }
}