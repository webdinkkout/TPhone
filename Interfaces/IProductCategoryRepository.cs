using CellPhoneS.Models;

namespace CellPhoneS.Interfaces;

public interface IProductCategoryService : IBaseService<ProductCategory>
{
    public bool Create(ProductCategory entity, IFormFile file);


}