using Microsoft.EntityFrameworkCore;
using Product.InventoryManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Persistence.DatabaseContext
{
    public class InventoryDatabaseContext : DbContext
    {
        public InventoryDatabaseContext(DbContextOptions<InventoryDatabaseContext> options) : base(options)
        {
            
        }

        // TODO: Add all the tables here
        // Ex.
        // public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<ProductItem> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(entity => entity.State == EntityState.Added || entity.State == EntityState.Modified))
            {
                entry.Entity.CreatedAt = DateTime.Now;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
