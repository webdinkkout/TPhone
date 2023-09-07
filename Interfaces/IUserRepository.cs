using CellPhoneS.Models;

namespace CellPhoneS.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    public User FindByUsername(string username);
}