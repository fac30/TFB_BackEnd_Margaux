using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFB_BackEnd_Margaux.Data;
using TFB_BackEnd_Margaux.Models;

namespace TFB_BackEnd_Margaux.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
} 