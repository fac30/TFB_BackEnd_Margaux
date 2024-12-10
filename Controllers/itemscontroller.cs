using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TFB_BackEnd_Margaux.Models;
using TFB_BackEnd_Margaux.Services;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsController(IItemService itemService)
    {
        _itemService = itemService;
    }

    // GET: api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        try
        {
            var items = await _itemService.GetAllItemsAsync();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error fetching items", error = ex.Message });
        }
    }

    // GET: api/items/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        try
        {
            var item = await _itemService.GetItemByIdAsync(id);
            if (item == null)
            {
                return NotFound(new { message = "Item not found" });
            }
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error fetching item", error = ex.Message });
        }
    }

    // POST: api/items
    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem(ItemDto itemDto)
    {
        try
        {
            var createdItem = await _itemService.CreateItemAsync(itemDto);
            return CreatedAtAction(nameof(GetItem), new { id = createdItem.Id }, createdItem);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Error creating item", error = ex.Message });
        }
    }

    // PUT: api/items/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, ItemDto itemDto)
    {
        try
        {
            var updatedItem = await _itemService.UpdateItemAsync(id, itemDto);
            if (updatedItem == null)
            {
                return NotFound(new { message = "Item not found" });
            }
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Error updating item", error = ex.Message });
        }
    }

    // DELETE: api/items/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteItem(int id)
    {
        try
        {
            var result = await _itemService.DeleteItemAsync(id);
            if (!result)
            {
                return NotFound(new { message = "Item not found" });
            }
            return Ok(new { message = "Item deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error deleting item", error = ex.Message });
        }
    }
}
