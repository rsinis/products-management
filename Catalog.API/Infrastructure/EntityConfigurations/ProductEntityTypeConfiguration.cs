using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.EntityConfigurations;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(cb => cb.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(cb => cb.Description)
            .IsRequired();

        builder.Property(cb => cb.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(cb => cb.ImageUrl)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(cb => cb.InStock)
            .HasDefaultValue(true);

        builder.HasOne(ci => ci.Category)
            .WithMany()
            .HasForeignKey(ci => ci.CategoryId);

        builder.HasMany(ci => ci.Reviews)
            .WithOne()
            .HasForeignKey(ci => ci.ProductId);

        builder.HasIndex(ci => ci.Name);
    }
}
