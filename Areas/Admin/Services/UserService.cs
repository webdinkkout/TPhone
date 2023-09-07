using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;

namespace CellPhoneS.Areas.Admin.Services;

public class UserService : BaseService<User>, IUserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public User FindByUsername(string username)
    {
        return this._dbContext.Users.FirstOrDefault(x => x.Username == username);
    }
}