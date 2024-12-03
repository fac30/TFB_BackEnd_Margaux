using Microsoft.AspNetCore.Http;

public class ClothingItemDto
{
    public int UserId { get; set; }
    public int CategoryId { get; set; }
    public string ItemDesc { get; set; }
    public IFormFile File { get; set; } // File to upload
}
