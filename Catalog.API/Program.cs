using Catalog.API.Endpoints;
using Catalog.API.Extensions;
using Catalog.API.Infrastructure;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddDefaultOpenApi();
builder.AddApplicationServices();

builder.Services.AddProblemDetails();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.

await ApplyMigrations(app);

app.UseDefaultOpenApi();

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Content")),
    RequestPath = "/Content"
});

app.UseCors("CorsPolicy");

app.MapGroup("/api/v1/catalog")
    .WithTags("Catalog API")
    .MapCatalogEndpoint();

app.Run();

static async Task ApplyMigrations(WebApplication app)
{
    var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<CatalogContext>();

    //NOTE: The Migrate method will only update the database if there any new migrations to add
    await db.Database.MigrateAsync();
}