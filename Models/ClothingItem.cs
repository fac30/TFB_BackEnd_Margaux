using TFB_BackEnd_Margaux.Models;

public class ClothingItem
{
    public ClothingItem()
    {
        OutfitItems = new List<OutfitItem>();
        ItemDesc = "";
    }

    public int ItemId { get; set; }
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public required string ItemDesc { get; set; }
    public string? PhotoLink { get; set; }
    public User? User { get; set; }
    public Category? Category { get; set; }
    public ICollection<OutfitItem> OutfitItems { get; set; }
}