using Microsoft.EntityFrameworkCore;

namespace TFB_BackEnd_Margaux.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Define DbSets for your entities here. For example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
