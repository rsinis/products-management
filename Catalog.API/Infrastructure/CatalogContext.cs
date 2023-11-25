using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure;

/// <remarks>
/// Add migrations using the following command inside the 'Catalog.API' project directory:
///
/// dotnet ef migrations add --context CatalogContext [migration-name]
/// dotnet ef migrations add InitialCreate --context CatalogContext -o Infrastructure/Migrations
/// </remarks>
public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options, IConfiguration configuration) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Product> Products { get; set; }
    //public DbSet<ProductLocation> ProductLocations { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //base.OnModelCreating(builder);
        CatalogContextSeed.SeedData(builder);
    }
}
