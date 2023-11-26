using Catalog.API.Endpoints;
using Catalog.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddDefaultOpenApi();
builder.AddApplicationServices();

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseDefaultOpenApi();

app.MapGroup("/api/v1/catalog")
    .WithTags("Catalog API")
    .MapCatalogEndpoint();

app.Run();
