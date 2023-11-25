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
                    Name = table.Column<string>(type: "TEXT", nullable: true)
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
                    Address = table.Column<string>(type: "TEXT", nullable: true)
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
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    InStock = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ratings = table.Column<string>(type: "TEXT", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category Sport" },
                    { 2, "Category Casual" },
                    { 3, "Category Formal" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "AAA H8A 0H1", "Location A" },
                    { 2, "BBB H8B 0H1", "Location B" },
                    { 3, "CCC H8C 0H1", "Location C" },
                    { 4, "DDD H8D 0H1", "Location D" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "InStock", "Name", "Price", "Ratings" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto.", "path/to/product1.jpg", true, "Product 1", 9.99m, null },
                    { 2, 2, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?", "path/to/product2.jpg", false, "Product 2", 7.99m, null },
                    { 3, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque.", "path/to/product3.jpg", true, "Product 3", 5.99m, null }
                });

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
