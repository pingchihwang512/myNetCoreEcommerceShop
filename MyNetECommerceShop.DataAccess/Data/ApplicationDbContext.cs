using Microsoft.EntityFrameworkCore;
using MyNetECommerceShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MyNetECommerceShop.Models;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ApplicationUser> ApplicationUser {  get; set; }
    public DbSet<OrderHeader> OrderHeaders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Clothing & Accessories", DisplayOrder = 1},
            new Category { Id = 2, Name = "Home & Furniture", DisplayOrder = 2},
            new Category { Id = 3, Name = "Electronics", DisplayOrder = 3},
            new Category { Id = 4, Name = "Books & Media", DisplayOrder = 4},
            new Category { Id = 5, Name = "Toys & Games", DisplayOrder = 5},
            new Category { Id = 6, Name = "Sports & Outdoors", DisplayOrder = 6},
            new Category { Id = 7, Name = "Beauty & Personal Care", DisplayOrder = 7},
            new Category { Id = 8, Name = "Collectibles & Antiques", DisplayOrder = 8},
            new Category { Id = 9, Name = "Others", DisplayOrder = 9}
        );


        modelBuilder.Entity<Company>().HasData(
            new Company { Id = 1, Name = "Tech Solution", StreetAddress ="1800 S 6th St" , City="Alhambra", PostalCode="91803", State="CA", PhoneNumber="6263254888" },
            new Company { Id = 2, Name = "Benn Furniture", StreetAddress = "123 N 2th St", City = "Alhambra", PostalCode = "91803", State = "CA", PhoneNumber = "6263254888" },
            new Company { Id = 3, Name = "William Health Center", StreetAddress = "22048 Protofino Dr", City = "Pomona", PostalCode = "91803", State = "CA", PhoneNumber = "6263254888" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Wood Table", ListPrice = 89.00, CategoryId = 2},
            new Product { ProductId = 2, ProductName = "Lazy sofa", ListPrice = 99.00, CategoryId = 2},
            new Product { ProductId = 3, ProductName = "Used Wood Chair", ListPrice = 29.00, CategoryId = 2},
            new Product { ProductId = 4, ProductName = "Lighter", ListPrice = 15.00, CategoryId = 9},
            new Product { ProductId = 5, ProductName = "Wood Shelf", ListPrice = 59.00, CategoryId = 2},
            new Product { ProductId = 6, ProductName = "Wood Table", ListPrice = 85.00, CategoryId = 2}
        );  
    }

}
