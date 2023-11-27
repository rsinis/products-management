using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImprovedCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "WildRunner");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Daybird");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Raptor Elite");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "http://localhost:5299/content/images/products/3.webp", "Alpine Fusion Goggles", 79.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "http://localhost:5299/content/images/products/11.webp", "Vertical Journey Climbing Shoes", 129.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "http://localhost:5299/content/images/products/24.webp", "Ridgevent Stealth Hiking Backpack", 69.99m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "InStock", "Name", "Price", "Ratings" },
                values: new object[] { 4, 2, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto.", "http://localhost:5299/content/images/products/25.webp", true, "Stealth Lite Bike Helmet", 79.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "Name", "Price", "Ratings" },
                values: new object[] { 5, 2, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "http://localhost:5299/content/images/products/39.webp", "Midnight Blue Goggles", 89.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "InStock", "Name", "Price", "Ratings" },
                values: new object[] { 6, 2, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque.", "http://localhost:5299/content/images/products/49.webp", true, "Arctic Shield Insulated Jacket", 169.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "Name", "Price", "Ratings" },
                values: new object[,]
                {
                    { 7, 2, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "http://localhost:5299/content/images/products/53.webp", "Raven Swift Snowboard", 129.99m, null },
                    { 8, 2, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "http://localhost:5299/content/images/products/62.webp", "Shadow Black Snowboard", 129.99m, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "InStock", "Name", "Price", "Ratings" },
                values: new object[] { 9, 3, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto.", "http://localhost:5299/content/images/products/63.webp", true, "Razor Climbing Harness", 79.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "Name", "Price", "Ratings" },
                values: new object[] { 10, 3, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "http://localhost:5299/content/images/products/74.webp", "Apex Climbing Harness", 89.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "InStock", "IsDeleted", "Name", "Price", "Ratings" },
                values: new object[] { 11, 3, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque.", "http://localhost:5299/content/images/products/86.webp", true, true, "ProVent Bike Helmet", 169.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "Name", "Price", "Ratings" },
                values: new object[] { 12, 3, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "http://localhost:5299/content/images/products/93.webp", "Summit Climbing Harness", 129.99m, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Category Sport");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Category Casual");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Category Formal");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name", "Price" },
                values: new object[] { "path/to/product1.jpg", "Product 1", 9.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 2, "path/to/product2.jpg", "Product 2", 7.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "ImageUrl", "Name", "Price" },
                values: new object[] { 3, "path/to/product3.jpg", "Product 3", 5.99m });
        }
    }
}
