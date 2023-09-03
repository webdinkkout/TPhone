using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Interfaces;

public interface IAuthService
{
    public bool Register(User user);
    public int LoginAdmin(string username, string password);
    public int Login(string username, string password);
}