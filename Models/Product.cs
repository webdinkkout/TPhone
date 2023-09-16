using System.ComponentModel.DataAnnotations;
using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class Product : BaseModel
{
    [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
    public string ProductName { get; set; }

    public string? SeoName { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập giá tiền sản phẩm")]
    public double Price { get; set; }

    public double PromotionPrice { get; set; } = 0;

    public int Rating { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập số lượng sản phẩm")]
    public int Quantity { get; set; }

    public bool IsHot { get; set; }

    public string? Desc { get; set; }

    public int ViewCount { get; set; }

    public string? ContentHtml { get; set; }

    public string? ThumbnailFilePath { get; set; }

    public string? ThumbnailFileName { get; set; }

    public int ProductCategoryId { get; set; }

    public int BrandId { get; set; }

    public int SupplierId { get; set; }

    public ProductCategory ProductCategory { get; set; } = null!;
    public Brand Brand { get; set; } = null!;
    public Supplier Supplier { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails = new List<OrderDetail>();
}