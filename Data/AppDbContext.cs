using Microsoft.EntityFrameworkCore;
using TFB_BackEnd_Margaux.Models;

namespace TFB_BackEnd_Margaux.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Outfit> Outfits { get; set; } // This will create the outfits table
    }
}
