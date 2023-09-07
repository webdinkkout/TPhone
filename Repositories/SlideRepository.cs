using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;

namespace CellPhoneS.Repositories;

public class SlideRepository : BaseRepository<Slide>, ISlideRepository
{
    public SlideRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}