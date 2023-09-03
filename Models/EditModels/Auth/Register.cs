using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Models.EditModels.Auth;

public class Register
{
    [Required(ErrorMessage = "Vui lòng nhập Họ và tên lót của bạn")]
    public string Firstname { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string PasswordConfirm { get; set; }
}