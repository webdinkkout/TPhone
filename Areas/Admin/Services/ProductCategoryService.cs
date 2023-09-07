using CellPhoneS.Common;
using CellPhoneS.Data;
using CellPhoneS.Interfaces;
using CellPhoneS.Models;
using CellPhoneS.Utils;

namespace CellPhoneS.Areas.Admin.Services;

public class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
{
    private readonly ApplicationDbContext _dbContext;
    public ProductCategoryService(ApplicationDbContext dbContext) : base(dbContext)
    {
        this._dbContext = dbContext;
    }

    public bool Create(ProductCategory entity, IFormFile file)
    {
        string[] thumbnailAttr = new HandleFile("images/category").Save(file);
        string seoName = HandleSeoName.GenerateSEOName(entity.Name);

        var createProductCategory = new ProductCategory
        {
            Id = entity.Id,
            Name = entity.Name,
            SeoName = seoName,
            ThumbnailFileName = thumbnailAttr[0],
            ThumbnailFilePath = thumbnailAttr[1],
        };

        return base.Create(createProductCategory);
    }

    public override bool Update(ProductCategory entity)
    {
        entity.SeoName = HandleSeoName.GenerateSEOName(entity.Name);

        return base.Update(entity);
    }

    public override bool DeleteById(int id)
    {
        var entity = this._dbContext.ProductCategories.Find(id);

        if (entity == null)
        {
            return false;
        }

        if (!string.IsNullOrEmpty(entity.ThumbnailFileName))
        {
            new HandleFile("/images/category").Delete(entity.ThumbnailFileName);
        }

        return base.DeleteById(id);
    }


}