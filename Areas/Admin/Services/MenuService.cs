using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Areas.Admin.Services;

public class MenuService : BaseService<Menu>, IMenuService
{
    public MenuService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override bool Create(Menu entity)
    {

        entity.Alias = HandleSeoName.GenerateSEONameNoPrefix(entity.Title);

        return base.Create(entity);
    }

}