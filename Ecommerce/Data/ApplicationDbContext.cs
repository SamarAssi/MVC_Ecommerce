using Microsoft.EntityFrameworkCore;

namespace Ecommerce;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EcommerceDb;User Id=sa;Password=Samar@2452;TrustServerCertificate=True;");
    }
}
