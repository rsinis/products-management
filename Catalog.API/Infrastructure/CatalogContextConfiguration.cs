using Catalog.API.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure;

public class CatalogContextConfiguration
{
    public static void Configure(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ProductEntityTypeConfiguration());
    }
}
