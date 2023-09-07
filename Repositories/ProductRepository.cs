using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    private ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public override bool Create(Product entity)
    {
        var seoName = HandleSeoName.GenerateSEOName(entity.ProductName);
        entity.SeoName = seoName;

        return base.Create(entity);
    }

    public override bool DeleteById(int id)
    {
        var deletedProduct = this.FindById(id);

        if (!string.IsNullOrEmpty(deletedProduct.ThumbnailFileName))
        {
            new HandleFile("/images/product").Delete(deletedProduct.ThumbnailFileName);
        }

        return base.DeleteById(id);
    }

    public List<Product> SearchProduct(int? categoryId, int? brandId, int? supplierId, string name)
    {
        IQueryable<Product> query = this._dbContext.Products;

        if (categoryId.HasValue)
        {
            query = query.Where(p => p.ProductCategoryId == categoryId);
        }

        if (brandId.HasValue)
        {
            query = query.Where(p => p.BrandId == brandId);
        }

        if (supplierId.HasValue)
        {
            query = query.Where(p => p.SupplierId == supplierId);
        }

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(p => p.ProductName.Contains(name));
        }

        return query.ToList();
    }

    public override bool Update(Product entity)
    {
        entity.SeoName = HandleSeoName.GenerateSEOName(entity.ProductName);
        return base.Update(entity);
    }
}