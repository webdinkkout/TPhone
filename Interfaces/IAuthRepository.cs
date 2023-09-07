using CellPhoneS.Models;

namespace CellPhoneS.Interfaces;

public interface IAuthRepository
{
    public bool Register(User user);
    public int LoginAdmin(string username, string password);
    public int Login(string username, string password);
}