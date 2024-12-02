

using TFB_BackEnd_Margaux.Models;

public class User
{
      public User()
    {
        Outfits = new List<Outfit>();
        ClothingItems = new List<ClothingItem>();
        Theme = "Light"; // Default value
    }

    public int UserId { get; set; }
    public required string Username { get; set; } = "";
    public required string Email { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public string Theme { get; set; } 
     public ICollection<Outfit> Outfits { get; set; }
     public ICollection<ClothingItem> ClothingItems { get; set; }


}
