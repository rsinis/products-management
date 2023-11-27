using Catalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Extensions;

public static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CatalogContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("CatalogDB"));
        });

        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
            });
        });
    }
}
