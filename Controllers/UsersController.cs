using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFB_BackEnd_Margaux.Data;
using TFB_BackEnd_Margaux.Models;

namespace TFB_BackEnd_Margaux.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
} 