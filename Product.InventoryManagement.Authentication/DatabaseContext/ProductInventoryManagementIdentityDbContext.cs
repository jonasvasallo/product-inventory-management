using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product.InventoryManagement.Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Authentication.DatabaseContext
{
    public class ProductInventoryManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ProductInventoryManagementIdentityDbContext(DbContextOptions<ProductInventoryManagementIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductInventoryManagementIdentityDbContext).Assembly);
        }
    }
}
