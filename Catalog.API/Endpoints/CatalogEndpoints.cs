using Catalog.API.Entities;
using Catalog.API.Helpers;
using Catalog.API.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Endpoints;

public static class CatalogEndpoints
{
    public static IEndpointRouteBuilder MapCatalogEndpoint(this IEndpointRouteBuilder app)
    {
        // Routes for querying catalog products

        app.MapGet("/products", GetAllProducts);
        app.MapGet("/products/{id:int}", GetProductById);

        app.MapGet("/products-deleted", GetAllDeletedProducts);

        return app;
    }

    public static async Task<Results<Ok<PaginatedItems<Product>>, BadRequest<string>>> GetAllProducts(
        [AsParameters] PaginationRequest paginationRequest, CatalogContext context)
    {
        var pageSize = paginationRequest.PageSize;
        var pageIndex = paginationRequest.PageIndex;

        var totalItems = await context.Products
            .LongCountAsync();

        var itemsOnPage = await context.Products
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return TypedResults.Ok(new PaginatedItems<Product>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static IResult GetAllDeletedProducts(CatalogContext context) => 
        Results.Ok(context.Products.IgnoreQueryFilters().Where(x => x.IsDeleted).ToList());

    public static async Task<Results<Ok<Product>, NotFound, BadRequest<string>>> GetProductById(
        CatalogContext context,
        int id)
    {
        if (id <= 0)
        {
            return TypedResults.BadRequest("Id is not valid.");
        }

        var product = await context.Products.IgnoreQueryFilters().SingleOrDefaultAsync(ci => ci.Id == id);

        if (product == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(product);
    }
}
