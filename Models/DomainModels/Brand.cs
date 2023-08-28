using CellPhoneS.Common;

namespace CellPhoneS.Models.DomainModels;

public class Brand : BaseModel
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();
}