using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Services;

public class AboutService : BaseService<About>, IAboutService
{
    public AboutService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }


}