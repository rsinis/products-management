﻿// <auto-generated />
using System;
using Catalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Catalog.API.Infrastructure.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Catalog.API.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Category Sport"
                        },
                        new
                        {
                            Id = 2,
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Category Casual"
                        },
                        new
                        {
                            Id = 3,
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Category Formal"
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "AAA H8A 0H1",
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Location A"
                        },
                        new
                        {
                            Id = 2,
                            Address = "BBB H8B 0H1",
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Location B"
                        },
                        new
                        {
                            Id = 3,
                            Address = "CCC H8C 0H1",
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Location C"
                        },
                        new
                        {
                            Id = 4,
                            Address = "DDD H8D 0H1",
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Location D"
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<bool>("InStock")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ratings")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit.Placeat amet ex aliquid quia repellat excepturi qui quos dignissimos necessitatibus dolore facilis obcaecati sunt suscipit sit esse harum ut, minima iusto.",
                            ImageUrl = "path/to/product1.jpg",
                            InStock = true,
                            IsDeleted = false,
                            Name = "Product 1",
                            Price = 9.99m
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Dicta, rerum error? Saepe ratione, nam commodi repellendus ullam dolorem non dolor illum recusandae dignissimos quo itaque sapiente quidem, quasi adipisci qui?",
                            ImageUrl = "path/to/product2.jpg",
                            InStock = false,
                            IsDeleted = false,
                            Name = "Product 2",
                            Price = 7.99m
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedAt = new DateTimeOffset(new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -5, 0, 0, 0)),
                            Description = "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Voluptas eligendi at veniam, inventore, architecto autem, rerum repellat perspiciatis voluptates pariatur expedita assumenda omnis aliquam quasi quia. Beatae totam maxime doloremque.",
                            ImageUrl = "path/to/product3.jpg",
                            InStock = true,
                            IsDeleted = true,
                            Name = "Product 3",
                            Price = 5.99m
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.ProductLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductLocation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            LocationId = 3,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            LocationId = 4,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 4,
                            LocationId = 2,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce porttitor.",
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eu laoreet justo. Integer consectetur massa purus, ut viverra nisl malesuada non. Nulla in ex sit amet urna interdum pharetra sed sed tortor. Vestibulum eleifend sollicitudin imperdiet. Suspendisse dapibus orci vel enim tincidunt ornare. Curabitur eu dolor vitae ante egestas semper. Ut rhoncus nisl et nulla feugiat, rhoncus mollis sem lacinia.\r\n\r\nNam malesuada nunc sit amet tortor faucibus finibus. Pellentesque pellentesque, neque consequat malesuada malesuada, orci mauris ultrices sem, nec vestibulum ex arcu at nibh. Interdum et malesuada fames ac ante ipsum primis in faucibus. Ut tortor justo, maximus et leo in, mollis imperdiet risus. Mauris finibus felis sit amet magna pellentesque, nec pretium diam congue. Suspendisse potenti. Cras cursus sollicitudin ultrices. Nulla in dui magna. Aliquam mattis nunc a enim laoreet, a pretium dolor malesuada.",
                            DateCreation = new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("Catalog.API.Entities.Product", b =>
                {
                    b.HasOne("Catalog.API.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Catalog.API.Entities.ProductLocation", b =>
                {
                    b.HasOne("Catalog.API.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.API.Entities.Product", "Product")
                        .WithMany("ProductLocations")
                        .HasForeignKey("ProductId");

                    b.Navigation("Location");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Catalog.API.Entities.Review", b =>
                {
                    b.HasOne("Catalog.API.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Catalog.API.Entities.Product", b =>
                {
                    b.Navigation("ProductLocations");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
