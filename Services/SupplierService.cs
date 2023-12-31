using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;

namespace CellPhoneS.Services;

public class SupplierService : BaseService<Supplier>, ISupplierService
{
    public SupplierService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}