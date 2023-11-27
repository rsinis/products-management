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
            new Location() { Id = 1, Name = "Location A", Address = "AAA H8A 0H1", DateCreation = new DateTime(2023, 11, 25) },
            new Location() { Id = 2, Name = "Location B", Address = "BBB H8B 0H1", DateCreation = new DateTime(2023, 11, 25) },
            new Location() { Id = 3, Name = "Location C", Address = "CCC H8C 0H1", DateCreation = new DateTime(2023, 11, 25) },
            new Location() { Id = 4, Name = "Location D", Address = "DDD H8D 0H1", DateCreation = new DateTime(2023, 11, 25) }
        );
    }

    private static void SeedCategories(ModelBuilder builder)
    {
        builder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "WildRunner", DateCreation = new DateTime(2023, 11, 25) },
            new Category() { Id = 2, Name = "Daybird", DateCreation = new DateTime(2023, 11, 25) },
            new Category() { Id = 3, Name = "Raptor Elite", DateCreation = new DateTime(2023, 11, 25) }
        );
    }

    private static void SeedProducts(ModelBuilder builder)
    {
        builder.Entity<Product>().HasData(
            new Product() { Id = 1, Name = "Alpine Fusion Goggles", Price = 79.99m, ImageUrl = "http://localhost:5299/content/images/products/3.webp", InStock = true, CategoryId = 1, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto." },
            new Product() { Id = 2, Name = "Vertical Journey Climbing Shoes", Price = 129.99m, ImageUrl = "http://localhost:5299/content/images/products/11.webp", InStock = false, CategoryId = 1, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" },
            new Product() { Id = 3, Name = "Ridgevent Stealth Hiking Backpack", Price = 69.99m, ImageUrl = "http://localhost:5299/content/images/products/24.webp", InStock = true, CategoryId = 1, IsDeleted = true, DeletedAt = new DateTime(2023, 11, 25), DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque." },

            new Product() { Id = 4, Name = "Stealth Lite Bike Helmet", Price = 79.99m, ImageUrl = "http://localhost:5299/content/images/products/25.webp", InStock = true, CategoryId = 2, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto." },
            new Product() { Id = 5, Name = "Midnight Blue Goggles", Price = 89.99m, ImageUrl = "http://localhost:5299/content/images/products/39.webp", InStock = false, CategoryId = 2, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" },
            new Product() { Id = 6, Name = "Arctic Shield Insulated Jacket", Price = 169.99m, ImageUrl = "http://localhost:5299/content/images/products/49.webp", InStock = true, CategoryId = 2, IsDeleted = false, DeletedAt = new DateTime(2023, 11, 25), DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque." },
            new Product() { Id = 7, Name = "Raven Swift Snowboard", Price = 129.99m, ImageUrl = "http://localhost:5299/content/images/products/53.webp", InStock = false, CategoryId = 2, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" },
            new Product() { Id = 8, Name = "Shadow Black Snowboard", Price = 129.99m, ImageUrl = "http://localhost:5299/content/images/products/62.webp", InStock = false, CategoryId = 2, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" },

            new Product() { Id = 9, Name = "Razor Climbing Harness", Price = 79.99m, ImageUrl = "http://localhost:5299/content/images/products/63.webp", InStock = true, CategoryId = 3, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto." },
            new Product() { Id = 10, Name = "Apex Climbing Harness", Price = 89.99m, ImageUrl = "http://localhost:5299/content/images/products/74.webp", InStock = false, CategoryId = 3, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" },
            new Product() { Id = 11, Name = "ProVent Bike Helmet", Price = 169.99m, ImageUrl = "http://localhost:5299/content/images/products/86.webp", InStock = true, CategoryId = 3, IsDeleted = true, DeletedAt = new DateTime(2023, 11, 25), DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque." },
            new Product() { Id = 12, Name = "Summit Climbing Harness", Price = 129.99m, ImageUrl = "http://localhost:5299/content/images/products/93.webp", InStock = false, CategoryId = 3, IsDeleted = false, DateCreation = new DateTime(2023, 11, 25), Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?" }
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
