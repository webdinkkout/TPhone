using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class Feedback : BaseModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Detail { get; set; }
}