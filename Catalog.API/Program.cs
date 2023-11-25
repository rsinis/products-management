using Catalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CatalogContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("CatalogDB"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Run();
