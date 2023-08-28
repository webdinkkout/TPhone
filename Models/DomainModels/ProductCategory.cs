using System.ComponentModel;
using CellPhoneS.Common;

namespace CellPhoneS.Models.DomainModels;

public class ProductCategory : BaseModel
{
    public string Name { get; set; }
    public string SeoName { get; set; }

    [DefaultValue(true)]
    public bool Status { get; set; }
    public string? ThumbnailFilePath { get; set; }
    public string? ThumbnailFileName { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();
}