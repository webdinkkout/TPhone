using CellPhoneS.Models;

namespace CellPhoneS.Interfaces;

public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
{
    public bool Create(ProductCategory entity, IFormFile file);


}