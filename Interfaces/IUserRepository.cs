using CellPhoneS.Models;

namespace CellPhoneS.Interfaces;

public interface IUserService : IBaseService<User>
{
    public User FindByUsername(string username);
}