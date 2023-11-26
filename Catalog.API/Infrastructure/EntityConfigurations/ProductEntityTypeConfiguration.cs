using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .IsRequired();

        builder.Property(e => e.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.ImageUrl)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.InStock)
            .HasDefaultValue(true);

        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId);

        builder.HasMany(e => e.ProductLocations)
            .WithOne(e => e.Product).IsRequired(false)
            .HasForeignKey(e => e.ProductId)
            .HasPrincipalKey(e => e.Id);

        builder.HasMany(e => e.Reviews)
            .WithOne(e => e.Product).IsRequired(false)
            .HasForeignKey(e => e.ProductId)
            .HasPrincipalKey(e => e.Id);

        builder.HasIndex(e => e.Name);

        builder.Property(e => e.IsDeleted)
            .HasDefaultValue(false);

        builder.HasQueryFilter(e => e.IsDeleted == false);
    }
}
