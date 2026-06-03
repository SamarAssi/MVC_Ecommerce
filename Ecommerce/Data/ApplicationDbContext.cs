using Microsoft.EntityFrameworkCore;

namespace Ecommerce;

public class ApplicationDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EcommerceDb;User Id=sa;Password=Samar@2452;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Mobiles"},
            new Category { Id = 2, Name = "Tablets"},
            new Category { Id = 3, Name = "Laptops"}
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "iPhone 13", Description = "Latest iPhone model", Price = 999.99m, Rate = 4.5, CategoryId = 1},
            new Product { Id = 2, Name = "Samsung Galaxy S21", Description = "Flagship Samsung phone", Price = 899.99m, Rate = 4.3, CategoryId = 1},
            new Product { Id = 3, Name = "iPad Pro", Description = "Powerful tablet from Apple", Price = 799.99m, Rate = 4.6, CategoryId = 2},
            new Product { Id = 4, Name = "Microsoft Surface Pro", Description = "Versatile tablet from Microsoft", Price = 899.99m, Rate = 4.4, CategoryId = 2},
            new Product { Id = 5, Name = "MacBook Pro", Description = "High-performance laptop from Apple", Price = 1299.99m, Rate = 4.7, CategoryId = 3},
            new Product { Id = 6, Name = "Dell XPS 13", Description = "Compact and powerful laptop from Dell", Price = 999.99m, Rate = 4.5, CategoryId = 3}
        );
    }
}
