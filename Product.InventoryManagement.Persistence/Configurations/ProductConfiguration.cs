using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.Property(p => p.Price)
                .HasColumnType("decimal(10, 2)"); // 10 total digits, 2 decimal places
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.CreatedAt)
                .HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UpdatedAt)
                .HasDefaultValue(DateTime.Now);

            builder.HasData(
                [
                    new ProductItem { Id = Guid.NewGuid(), Name = "Mouse", Price = 1400.99M, Quantity = 12, Description = "Mouse na malibag", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new ProductItem { Id = Guid.NewGuid(), Name = "Keyboard", Price = 2250, Quantity = 6, Description = "Keyboard na sira Enter key", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                    new ProductItem { Id = Guid.NewGuid(), Name = "Headphones", Price = 1600.50M, Quantity = 24, Description = "Pwedeng pang halo sa sinigang", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                ]
            );
        }
    }
}
