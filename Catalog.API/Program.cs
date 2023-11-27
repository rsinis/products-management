using Catalog.API.Endpoints;
using Catalog.API.Extensions;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddDefaultOpenApi();
builder.AddApplicationServices();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

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
