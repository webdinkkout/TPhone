using CellPhoneS.Common;

namespace CellPhoneS.Models.DomainModels;

public class User : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string? AvatarFilePath { get; set; }

    public string? AvatarFileName { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public string RoleId { get; set; }

    public Role Role { get; set; }
}