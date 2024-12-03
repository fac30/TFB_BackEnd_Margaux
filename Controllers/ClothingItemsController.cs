using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ClothingItemsController : ControllerBase
{
    private readonly ClothingItemService _clothingItemService;

    public ClothingItemsController(SupabaseClient supabaseClient)
    {
        _clothingItemService = new ClothingItemService(supabaseClient.GetClient());
    }

    [HttpPost]
    public async Task<IActionResult> CreateClothingItem([FromForm] ClothingItemDto clothingItemDto)
    {
        var clothingItem = new ClothingItem
        {
            UserId = clothingItemDto.UserId,
            CategoryId = clothingItemDto.CategoryId,
            ItemDesc = clothingItemDto.ItemDesc
        };

        await _clothingItemService.AddClothingItemAsync(clothingItem, clothingItemDto.File);

        return CreatedAtAction(nameof(GetClothingItem), new { id = clothingItem.ItemId }, clothingItem);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClothingItem(int id)
    {
        // Implement the logic to get a clothing item by id
        // For now, return NotFound
        return NotFound();
    }

    // Add other actions like GetClothingItem, etc.
}
