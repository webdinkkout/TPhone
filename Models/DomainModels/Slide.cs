using CellPhoneS.Common;

namespace CellPhoneS.Models.DomainModels;

public class Slide : BaseModel
{
    public string Name { get; set; }
    public string ThumbnailFilePath { get; set; }
    public string? ThumbnailFileName { get; set; }

    public string Link { get; set; }

    public string Sort { get; set; }

}