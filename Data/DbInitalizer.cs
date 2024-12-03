using TFB_BackEnd_Margaux.Models;
using Microsoft.EntityFrameworkCore;

namespace TFB_BackEnd_Margaux.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Check if there are any users already
            if (context.Users.Any())
            {
                return; // DB has been seeded
            }

            // Create some dummy users
            var users = new User[]
            {
                new User { Username = "Alice", Email = "alice@example.com", Theme = "Light", CreatedAt = DateTime.UtcNow },
                new User { Username = "Bob", Email = "bob@example.com", Theme = "Dark", CreatedAt = DateTime.UtcNow }
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            // Create some dummy categories
            var categories = new Category[]
            {
                new Category { CategoryName = "Tops", DefaultName = "Top", Colour = "Red", Region = "Upper Body" },
                new Category { CategoryName = "Bottoms", DefaultName = "Bottom", Colour = "Blue", Region = "Lower Body" }
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }
            context.SaveChanges();

            // Create some dummy clothing items
            var clothingItems = new ClothingItem[]
            {
                new ClothingItem { 
                    UserId = users[0].UserId, 
                    CategoryId = categories[0].CategoryId, 
                    ItemDesc = "White T-Shirt" 
                },
                new ClothingItem { 
                    UserId = users[0].UserId, 
                    CategoryId = categories[1].CategoryId, 
                    ItemDesc = "Blue Jeans" 
                }
            };

            foreach (var item in clothingItems)
            {
                context.ClothingItems.Add(item);
            }
            context.SaveChanges();

            // Create some dummy outfits
            var outfits = new Outfit[]
            {
                new Outfit { 
                    UserId = users[0].UserId, 
                    OutfitName = "Casual Day", 
                    CreatedAt = DateTime.UtcNow 
                }
            };

            foreach (var outfit in outfits)
            {
                context.Outfits.Add(outfit);
            }
            context.SaveChanges();

            // Create outfit items (connections between outfits and clothing items)
            var outfitItems = new OutfitItem[]
            {
                new OutfitItem { 
                    OutfitId = outfits[0].OutfitId, 
                    ItemId = clothingItems[0].ItemId, 
                    AddedAt = DateTime.UtcNow 
                },
                new OutfitItem { 
                    OutfitId = outfits[0].OutfitId, 
                    ItemId = clothingItems[1].ItemId, 
                    AddedAt = DateTime.UtcNow 
                }
            };

            foreach (var outfitItem in outfitItems)
            {
                context.OutfitItems.Add(outfitItem);
            }
            context.SaveChanges();
        }
    }
}
