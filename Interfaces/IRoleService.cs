using CellPhoneS.Models;

namespace CellPhoneS.Interfaces;

public interface IRoleService : IBaseService<Role>
{
    public Role FindByStrId(string id);
}