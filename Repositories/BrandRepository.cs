using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;

namespace CellPhoneS.Repositories;

public class BrandRepository : BaseRepository<Brand>, IBrandRepository
{
    public BrandRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}