namespace CellPhoneS.Areas.Admin.Models.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SeoName { get; set; }

    public string? ThumbnailFilePath { get; set; }

    public CategoryViewModel(int Id, string Name, string SeoName, string ThumbnailFilePath = "")
    {
        this.Id = Id;
        this.Name = Name;
        this.ThumbnailFilePath = ThumbnailFilePath;
        this.SeoName = SeoName;
    }
}