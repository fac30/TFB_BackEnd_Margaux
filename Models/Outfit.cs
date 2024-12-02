using System;

namespace TFB_BackEnd_Margaux.Models;

public class Outfit
{
    public int OutfitId { get; set; }
    public int UserId { get; set; }
    public required string OutfitName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}