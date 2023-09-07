using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class User : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string? AvatarFilePath { get; set; }

    public string? AvatarFileName { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    [NotMapped]
    public string PasswordConfirm { get; set; }
    public string RoleId { get; set; }

    public Role Role { get; set; } = null!;
}