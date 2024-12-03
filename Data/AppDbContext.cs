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

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Outfit> Outfits { get; set; }
        public DbSet<ClothingItem> ClothingItems { get; set; }
        public DbSet<OutfitItem> OutfitItems { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the many-to-many relationship
        modelBuilder.Entity<OutfitItem>()
            .HasKey(oi => new { oi.OutfitId, oi.ItemId });

        // Configure default timestamp behavior
        modelBuilder.Entity<User>()
            .Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Outfit>()
            .Property(o => o.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<OutfitItem>()
            .Property(oi => oi.AddedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Configure User-Outfit relationship
        modelBuilder.Entity<Outfit>()
            .HasOne(o => o.User)
            .WithMany(u => u.Outfits)
            .HasForeignKey(o => o.UserId);

        // Configure User-ClothingItem relationship
        modelBuilder.Entity<ClothingItem>()
            .HasOne(c => c.User)
            .WithMany(u => u.ClothingItems)
            .HasForeignKey(c => c.UserId);

        // Configure Category-ClothingItem relationship
        modelBuilder.Entity<ClothingItem>()
            .HasOne(c => c.Category)
            .WithMany(cat => cat.ClothingItems)
            .HasForeignKey(c => c.CategoryId);

        // Configure ClothingItem primary key
        modelBuilder.Entity<ClothingItem>()
            .HasKey(c => c.ItemId);
    }
    }
}
