using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Areas.Admin.Models.ViewModels;


public class ProductViewModel
{
    public int Id { get; set; }
    public string ProductName { get; set; }

    public string SeoName { get; set; }

    public double Price { get; set; }

    public string? ThumbnailFilePath { get; set; }

    public int Quantity { get; set; }

    public int ProductCategoryId { get; set; }

    public int BrandId { get; set; }

    public int SupplierId { get; set; }

    public List<ProductCategory>? ProductCategories { get; set; }
    public List<Brand>? Brands { get; set; }
    public List<Supplier>? Suppliers { get; set; }
}