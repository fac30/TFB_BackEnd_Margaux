using System;

namespace TFB_BackEnd_Margaux.Models;

public class Outfit
{
    public Outfit()
    {
        OutfitItems = new List<OutfitItem>();
        OutfitName = "";
        CreatedAt = DateTime.UtcNow;
    }

    public int OutfitId { get; set; }
    public int UserId { get; set; }
    public required string OutfitName { get; set; }
    public DateTime CreatedAt { get; set; }
    public User? User { get; set; }
    public ICollection<OutfitItem> OutfitItems { get; set; }
}
