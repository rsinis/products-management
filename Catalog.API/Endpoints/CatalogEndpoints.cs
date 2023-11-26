using Catalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Endpoints;

public static class CatalogEndpoints
{
    public static IEndpointRouteBuilder MapCatalogEndpoint(this IEndpointRouteBuilder app)
    {
        // Routes for querying catalog products
        app.MapGet("/products", GetAllProducts);
        app.MapGet("/products-deleted", GetAllDeletedProducts);

        return app;
    }

    public static IResult GetAllProducts(CatalogContext context) => Results.Ok(context.Products.ToList());
    public static IResult GetAllDeletedProducts(CatalogContext context) => Results.Ok(context.Products.IgnoreQueryFilters().ToList());
}
