using System.ComponentModel.DataAnnotations;
using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class OrderDetail : BaseModel
{
    [Key]
    public int OrderId { get; set; }
    [Key]
    public int ProductId { get; set; }

    public int ProductName { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }

    public Orders Orders { get; set; } = null!;
    public Product Product { get; set; } = null!;
}