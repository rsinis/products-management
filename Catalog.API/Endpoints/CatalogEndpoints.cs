using Catalog.API.Dtos;
using Catalog.API.Entities;
using Catalog.API.Helpers;
using Catalog.API.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Endpoints;

public static class CatalogEndpoints
{
    private const string ContentType = "application/json";
    private const string Tag = "Products";

    public static IEndpointRouteBuilder MapCatalogEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/items", CreateProduct)
            .WithName("CreateProduct")
            .WithTags(Tag);

        app.MapPut("/items", UpdateProduct)
            .WithName("UpdateProduct")
            .WithTags(Tag);

        app.MapGet("/products", GetAllProducts)
            .WithName("GetProducts")
            .WithTags(Tag);

        app.MapGet("/products/{id:int}", GetProductById)
            .WithName("GetProduct")
            .WithTags(Tag);

        app.MapDelete("/products/{id:int}", DeleteProductById)
            .WithName("DeleteProduct")
            .WithTags(Tag);

        app.MapGet("/products/deleted", GetAllDeletedProducts)
            .WithName("GetDeletedProducts")
            .WithTags(Tag);

        app.MapPut("/products/{id:int}/restore", RestoreProductById)
            .WithName("RestoreProduct")
            .WithTags(Tag);

        app.MapDelete("/products/{id:int}/remove", RemoveProductById)
            .WithName("RemoveProduct")
            .WithTags(Tag);

        return app;
    }

    public static async Task<IResult> CreateProduct(
        CatalogContext context,
        ProductToCreateDto productToCreate,
        IValidator<ProductToCreateDto> validator)
    {
        var validationResult = await validator.ValidateAsync(productToCreate);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var product = new Product
        {
            Name = productToCreate.Name,
            Description = productToCreate.Description,
            ImageUrl = productToCreate.ImageUrl,
            Price = productToCreate.Price,
            InStock = productToCreate.InStock,
            CategoryId = productToCreate.CategoryId,
        };

        product.Ratings = new int[] { productToCreate.Rating };
        product.ProductLocations = productToCreate.Locations?.Select(x => new ProductLocation { LocationId = x }).ToList();

        context.Products.Add(product);
        await context.SaveChangesAsync();

        // TODO: Return ProductToReturnDto

        return TypedResults.CreatedAtRoute(product, $"/products/{product.Id}");
    }

    public static async Task<IResult> UpdateProduct(
        CatalogContext context,
        ProductToUpdateDto productToUpdate,
        IValidator<ProductToUpdateDto> validator)
    {
        var validationResult = await validator.ValidateAsync(productToUpdate);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var product = await context.Products.SingleOrDefaultAsync(i => i.Id == productToUpdate.Id);

        if (product == null)
        {
            return TypedResults.NotFound($"Product with id {productToUpdate.Id} not found.");
        }

        // Update current product
        product.Name = productToUpdate.Name;
        product.Description = productToUpdate.Description;
        product.ImageUrl = productToUpdate.ImageUrl;
        product.Price = productToUpdate.Price;
        product.InStock = productToUpdate.InStock;
        product.CategoryId = productToUpdate.CategoryId;

        var productEntry = context.Entry(product);
        productEntry.State = EntityState.Modified;
        await context.SaveChangesAsync();

        // TODO: Return ProductToReturnDto

        return TypedResults.Created($"/api/v1/catalog/products/{productToUpdate.Id}");
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

        // TODO: Return PaginatedItems<ProductToReturnDto>
        return TypedResults.Ok(new PaginatedItems<Product>(pageIndex, pageSize, totalItems, itemsOnPage));
    }

    public static IResult GetAllDeletedProducts(CatalogContext context) =>
        // TODO: Return List<ProductToReturnDto>
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

        // TODO: Return ProductToReturnDto
        return TypedResults.Ok(product);
    }

    public static async Task<Results<Created, NotFound<string>>> RestoreProductById(
        CatalogContext context,
        int id)
    {
        var product = await context.Products.IgnoreQueryFilters().SingleOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            return TypedResults.NotFound($"Product with id {id} not found.");
        }

        // Update current product
        product.IsDeleted = false;
        var productEntry = context.Entry(product);
        productEntry.State = EntityState.Modified;
        await context.SaveChangesAsync();

        return TypedResults.Created($"/api/v1/catalog/products/{id}");
    }

    public static async Task<Results<NoContent, NotFound>> DeleteProductById(
        CatalogContext context,
        int id)
    {
        var product = await context.Products.SingleOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            return TypedResults.NotFound();
        }

        context.Products.Remove(product);
        await context.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    public static async Task<Results<NoContent, NotFound>> RemoveProductById(
        CatalogContext context,
        int id)
    {
        var product = await context.Products.IgnoreQueryFilters()
            .SingleOrDefaultAsync(x => x.Id == id);

        if (product is null)
        {
            return TypedResults.NotFound();
        }

        context.Database.ExecuteSqlInterpolated($"DELETE FROM ProductLocation WHERE ProductId = {id}");
        context.Database.ExecuteSqlInterpolated($"DELETE FROM Reviews WHERE ProductId = {id}");
        context.Database.ExecuteSqlInterpolated($"DELETE FROM Products WHERE Id = {id}");
        return TypedResults.NoContent();
    }
}
