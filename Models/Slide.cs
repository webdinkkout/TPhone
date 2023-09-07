using CellPhoneS.Common;

namespace CellPhoneS.Models;

public class Slide : BaseModel
{
    public string Name { get; set; }
    public string ThumbnailFilePath { get; set; }
    public string? ThumbnailFileName { get; set; }

    public string Link { get; set; }

    public int Sort { get; set; }

}