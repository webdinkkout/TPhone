using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Areas.Admin.Services;

public class ProductService : BaseService<Product>, IProductService
{
    public ProductService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}