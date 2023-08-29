using CellPhoneS.Common;

namespace CellPhoneS.Models.DomainModels;

public class Menu : BaseModel
{
    public string Name { get; set; }
    public string Target { get; set; }

    public string Link { get; set; }

    public string Desc { get; set; }

    public bool Status { get; set; }

    public int Position { get; set; }
}