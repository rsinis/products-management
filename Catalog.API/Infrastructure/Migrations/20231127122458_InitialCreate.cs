using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModification = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModification = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InStock = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    Ratings = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModification = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    DateCreation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateModification = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DateCreation", "DateModification", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "WildRunner" },
                    { 2, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Daybird" },
                    { 3, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Raptor Elite" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "DateCreation", "DateModification", "Name" },
                values: new object[,]
                {
                    { 1, "AAA H8A 0H1", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Location A" },
                    { 2, "BBB H8B 0H1", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Location B" },
                    { 3, "CCC H8C 0H1", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Location C" },
                    { 4, "DDD H8D 0H1", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Location D" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "InStock", "Name", "Price", "Ratings" },
                values: new object[] { 1, 1, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto.", "http://localhost:5299/content/images/products/3.webp", true, "Alpine Fusion Goggles", 79.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "Name", "Price", "Ratings" },
                values: new object[] { 2, 1, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "http://localhost:5299/content/images/products/11.webp", "Vertical Journey Climbing Shoes", 129.99m, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "DateCreation", "DateModification", "DeletedAt", "Description", "ImageUrl", "InStock", "IsDeleted", "Name", "Price", "Ratings" },
                values: new object[] { 3, 1, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTimeOffset(new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)), "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque.", "http://localhost:5299/content/images/products/24.webp", true, true, "Ridgevent Stealth Hiking Backpack", 69.99m, null });

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

            migrationBuilder.InsertData(
                table: "ProductLocation",
                columns: new[] { "Id", "LocationId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 4, 2 },
                    { 4, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "DateCreation", "DateModification", "ProductId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porttitor.", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eu laoreet justo. Integer consectetur massa purus, ut viverra nisl malesuada non. Nulla in ex sit amet urna interdum pharetra sed sed tortor. Vestibulum eleifend sollicitudin imperdiet. Suspendisse dapibus orci vel enim tincidunt ornare. Curabitur eu dolor vitae ante egestas semper. Ut rhoncus nisl et nulla feugiat, rhoncus mollis sem lacinia.\r\n\r\nNam malesuada nunc sit amet tortor faucibus finibus. Pellentesque pellentesque, neque consequat malesuada malesuada, orci mauris ultrices sem, nec vestibulum ex arcu at nibh. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut tortor justo, maximus et leo in, mollis imperdiet risus. Mauris finibus felis sit amet magna pellentesque, nec pretium diam congue. Suspendisse potenti. Cras cursus sollicitudin ultrices. Nulla in dui magna. Aliquam mattis nunc a enim laoreet, a pretium dolor malesuada.", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_LocationId",
                table: "ProductLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_ProductId",
                table: "ProductLocation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductLocation");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
