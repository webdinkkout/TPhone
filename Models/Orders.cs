using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class Orders : BaseModel
{
    public DateTime OrderDate { get; set; }

    public bool Status { get; set; }

    public bool Delivered { get; set; }
    public bool DeliveryDate { get; set; }
    public int CustomerId { get; set; }

    public ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}