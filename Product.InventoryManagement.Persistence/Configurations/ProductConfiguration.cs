using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.InsertUsingStoredProcedure("sp_create_product", sp =>
            {
                sp.HasParameter("Id");
                sp.HasParameter("Name");
                sp.HasParameter("Description");
                sp.HasParameter("Price");
                sp.HasParameter("Quantity");
                sp.HasParameter("CreatedAt");
                sp.HasParameter("UpdatedAt");
            });

            builder.UpdateUsingStoredProcedure("sp_update_product", sp =>
            {
                sp.HasOriginalValueParameter("Id");
                sp.HasParameter("Name");
                sp.HasParameter("Description");
                sp.HasParameter("Price");
                sp.HasParameter("Quantity");
                sp.HasOriginalValueParameter("CreatedAt");
                sp.HasParameter("UpdatedAt");
            });

            builder.DeleteUsingStoredProcedure("sp_delete_product", sp =>
            {
                sp.HasOriginalValueParameter("Id");
            });

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedNever();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(10, 2)"); // 10 total digits, 2 decimal places
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.CreatedAt)
                .IsRequired();
            builder.Property(p => p.UpdatedAt)
                .IsRequired();

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
