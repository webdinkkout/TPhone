using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class Menu : BaseModel
{
    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Alias { get; set; }

    public int Position { get; set; }
}