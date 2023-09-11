using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;

namespace CellPhoneS.Services;

public class SlideService : BaseService<Slide>, ISlideService
{
    public SlideService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}