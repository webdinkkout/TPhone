using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;

namespace CellPhoneS.Areas.Admin.Services;

public class BrandService : BaseService<Brand>, IBrandService
{
    public BrandService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}