namespace CellPhoneS.Common;

public class UserLogin
{
    public int Id { get; set; }

    private string FirstName { get; set; }
    private string LastName { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public string Email { get; set; }

    public string AvatarFilePath { get; set; }
}