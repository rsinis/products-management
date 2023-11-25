using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure;

public class CatalogContextSeed
{
    public static void SeedData(ModelBuilder builder)
    {
        SeedLocations(builder);
        SeedCategories(builder);
        SeedProducts(builder);
        SeedProductLocations(builder);
        SeedReviews(builder);
    }

    private static void SeedLocations(ModelBuilder builder)
    {
        builder.Entity<Location>().HasData(
            new Location() { Id = 1, Name = "Location A", Address = "AAA H8A 0H1" },
            new Location() { Id = 2, Name = "Location B", Address = "BBB H8B 0H1" },
            new Location() { Id = 3, Name = "Location C", Address = "CCC H8C 0H1" },
            new Location() { Id = 4, Name = "Location D", Address = "DDD H8D 0H1" }
        );
    }

    private static void SeedCategories(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Category Sport" },
            new Category() { Id = 2, Name = "Category Casual" },
            new Category() { Id = 3, Name = "Category Formal" }
        );
    }

    private static void SeedProducts(ModelBuilder builder)
    {
        builder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Product 1", Price = 9.99m, ImageUrl = "path/to/product1.jpg", InStock = true, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto." },
            new Product() { Id = 2, Name = "Product 2", Price = 7.99m, ImageUrl = "path/to/product2.jpg", InStock = false, CategoryId = 2, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" },
            new Product() { Id = 3, Name = "Product 3", Price = 5.99m, ImageUrl = "path/to/product3.jpg", InStock = true, CategoryId = 3, Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque." }
        );
    }
    private static void SeedProductLocations(ModelBuilder builder)
    {
        builder.Entity<ProductLocation>().HasData(
            new ProductLocation() { Id = 1, ProductId = 1, LocationId = 1 },
            new ProductLocation() { Id = 2, ProductId = 1, LocationId = 3 },
            new ProductLocation() { Id = 3, ProductId = 2, LocationId = 4 },
            new ProductLocation() { Id = 4, ProductId = 3, LocationId = 2 }
        );
    }

    private static void SeedReviews(ModelBuilder builder)
    {
        builder.Entity<Review>().HasData(
            new Review() { Id = 1, DateCreation = new DateTime(2023, 11, 25), ProductId = 1, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porttitor.", },
            new Review() { Id = 2, DateCreation = new DateTime(2023, 11, 25), ProductId = 3, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eu laoreet justo. Integer consectetur massa purus, ut viverra nisl malesuada non. Nulla in ex sit amet urna interdum pharetra sed sed tortor. Vestibulum eleifend sollicitudin imperdiet. Suspendisse dapibus orci vel enim tincidunt ornare. Curabitur eu dolor vitae ante egestas semper. Ut rhoncus nisl et nulla feugiat, rhoncus mollis sem lacinia.\r\n\r\nNam malesuada nunc sit amet tortor faucibus finibus. Pellentesque pellentesque, neque consequat malesuada malesuada, orci mauris ultrices sem, nec vestibulum ex arcu at nibh. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut tortor justo, maximus et leo in, mollis imperdiet risus. Mauris finibus felis sit amet magna pellentesque, nec pretium diam congue. Suspendisse potenti. Cras cursus sollicitudin ultrices. Nulla in dui magna. Aliquam mattis nunc a enim laoreet, a pretium dolor malesuada.", }
        );
    }
}
