using System.ComponentModel.DataAnnotations;
using CellPhoneS.Models.DomainModels;

namespace CellPhoneS.Areas.Admin.Models.EditModels.Product;

public class UpdateProduct
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm không đúng")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm")]
    [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm không đúng")]
    public double PromotionPrice { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập số lượng sản phẩm")]
    [Range(0, double.MaxValue, ErrorMessage = "Số lượng sản phẩm không đúng")]
    public int Quantity { get; set; }

    public bool IsHot { get; set; }

    public string? Desc { get; set; }

    public string? ContentHtml { get; set; }

    public int ProductCategoryId { get; set; }

    public int BrandId { get; set; }

    public int SupplierId { get; set; }
    public string? ThumbnailFilePath { get; set; }

    public string? ThumbnailFileName { get; set; }
    public List<ProductCategory>? ProductCategories { get; set; }
    public List<Brand>? Brands { get; set; }
    public List<Supplier>? Suppliers { get; set; }
}