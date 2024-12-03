using TFB_BackEnd_Margaux.Models;

public class OutfitItem
{
    public OutfitItem()
    {
        AddedAt = DateTime.UtcNow;
    }

    public int OutfitId { get; set; }
    public int ItemId { get; set; }
    public DateTime AddedAt { get; set; }
    public Outfit? Outfit { get; set; }
    public ClothingItem? ClothingItem { get; set; }
}