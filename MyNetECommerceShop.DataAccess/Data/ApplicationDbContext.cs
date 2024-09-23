using Microsoft.EntityFrameworkCore;
using MyNetECommerceShop.Models;

namespace MyNetECommerceShop.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Clothing & Accessories", DisplayOrder = 1 },
            new Category { CategoryId = 2, Name = "Home & Furniture", DisplayOrder = 2},
            new Category { CategoryId = 3, Name = "Electronics", DisplayOrder = 3},
            new Category { CategoryId = 4, Name = "Books & Media", DisplayOrder = 4},
            new Category { CategoryId = 5, Name = "Toys & Games", DisplayOrder = 5},
            new Category { CategoryId = 6, Name = "Sports & Outdoors", DisplayOrder = 6},
            new Category { CategoryId = 7, Name = "Beauty & Personal Care", DisplayOrder = 7},
            new Category { CategoryId = 8, Name = "Collectibles & Antiques", DisplayOrder = 8},
            new Category { CategoryId = 9, Name = "Others", DisplayOrder = 9}
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Title = "Wood Table", Description = "", ListPrice = 89.00, ImageURL=""},
            new Product { ProductId = 2, Title = "Lazy sofa", Description = "", ListPrice = 99.00, ImageURL = ""},
            new Product { ProductId = 3, Title = "Used Wood Chair", Description = "", ListPrice = 29.00, ImageURL = ""},
            new Product { ProductId = 4, Title = "Lighter", Description = "" , ListPrice = 15.00, ImageURL = ""},
            new Product { ProductId = 5, Title = "Wood Shelf", Description = "", ListPrice = 59.00, ImageURL = ""},
            new Product { ProductId = 6, Title = "Wood Table", Description = "", ListPrice = 85.00, ImageURL = ""}
        );  
    }

}
