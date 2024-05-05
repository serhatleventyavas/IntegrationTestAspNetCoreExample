using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.TypeConfigurations;

public sealed class ProductTypeConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("products");

        builder.HasIndex(p => p.Id).IsUnique();
        builder.Property(p => p.Id)
                        .IsRequired();

        builder.Property(p => p.Name)
                        .HasMaxLength(120)
                        .IsRequired();

        builder.Property(p => p.Description)
                        .HasMaxLength(1000)
                        .IsRequired();
        
        builder.Property(p => p.ImageLink)
                        .HasMaxLength(255)
                        .IsRequired();

        builder.Property(p => p.Price)
                        .IsRequired();
        
        builder.Property(p => p.Quantity)
                        .IsRequired();
        
    }
}