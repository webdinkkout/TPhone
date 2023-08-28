using CellPhoneS.Common;

namespace CellPhoneS.Models.DomainModels;

public class Supplier : BaseModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();
}