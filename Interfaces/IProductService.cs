using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Interfaces;

public interface IProductService : IBaseService<Product>
{
    public List<Product> SearchProduct(int? categoryId, int? brandId, int? supplierId, string name);
}