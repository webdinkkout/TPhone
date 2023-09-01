using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models.DomainModels;
using CellPhoneS.Utils;

namespace CellPhoneS.Areas.Admin.Services;

public class ProductService : BaseService<Product>, IProductService
{
    private ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext) : base(dbContext)
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
}