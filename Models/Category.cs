using TFB_BackEnd_Margaux.Models;

public class Category
{
    public Category()
    {
        ClothingItems = new List<ClothingItem>();
        CategoryName = "";
        DefaultName = "";
        Colour = "";
        Region = "";
    }

    public int CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public required string DefaultName { get; set; }
    public string Colour { get; set; }
    public string Region { get; set; }
    public ICollection<ClothingItem> ClothingItems { get; set; }
}
