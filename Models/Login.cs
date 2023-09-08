using System.ComponentModel.DataAnnotations;

namespace CellPhoneS.Models;

public class Login
{
    [Required(ErrorMessage = "Vui lòng nhập tên tài khoản")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}