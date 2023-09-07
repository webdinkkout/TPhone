using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Repositories;

public class MenuRepository : BaseRepository<Menu>, IMenuRepository
{
    public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override bool Create(Menu entity)
    {

        entity.Alias = HandleSeoName.GenerateSEONameNoPrefix(entity.Title);

        return base.Create(entity);
    }

}