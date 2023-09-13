using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Services;

public class RoleService : BaseService<Role>, IRoleService
{
    private readonly ApplicationDbContext _dbContext;

    public RoleService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public Role FindByStrId(string id)
    {
        return _dbContext.Roles.FirstOrDefault(x => x.Id == id);
    }

}