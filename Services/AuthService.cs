using BCrypt.Net;
using CellPhoneS.Constants;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Services;

public class AuthService : IAuthService
{
    private readonly IUserService userService;

    public AuthService(IUserService userService)
    {
        this.userService = userService;
    }


    public int LoginAdmin(string username, string password)
    {
        var userExists = this.userService.FindByUsername(username);
        if (userExists == null)
        {
            return (int)LoginState.STRONG_EMAIL;
        }

        var passwordPasses = BCrypt.Net.BCrypt.Verify(password, userExists.Password);

        if (!passwordPasses)
        {
            return (int)LoginState.STRONG_PASSWORD;
        }

        if (userExists.RoleId != "ADMIN")
        {
            return (int)LoginState.AUTH;
        }

        return userExists.Id;
    }

    public int Login(string username, string password)
    {
        var userExists = this.userService.FindByUsername(username);
        if (userExists == null)
        {
            return (int)LoginState.STRONG_EMAIL;
        }

        var passwordPasses = BCrypt.Net.BCrypt.Verify(password, userExists.Password);

        if (!passwordPasses)
        {
            return (int)LoginState.STRONG_PASSWORD;
        }

        return userExists.Id;
    }

    public bool Register(User user)
    {
        var userRes = this.userService.FindById(user.Id);


        if (userRes != null)
        {
            return false;
        }

        var salt = BCrypt.Net.BCrypt.GenerateSalt(10);
        var passwordHashed = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);

        var newUser = new User
        {
            LastName = user.LastName,
            FirstName = user.FirstName,
            Username = user.Username,
            Password = passwordHashed,
            RoleId = "MEMBER"
        };

        var createdUserSuccess = this.userService.Create(newUser);
        if (!createdUserSuccess)
        {
            return false;
        }

        return true;
    }
}