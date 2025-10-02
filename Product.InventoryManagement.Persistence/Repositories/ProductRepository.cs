using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Persistence.Repositories
{
    public class ProductRepository : GenericRepository<ProductItem>, IProductRepository
    {
        public ProductRepository(InventoryDatabaseContext context) : base(context)
        {
            
        }

        public async Task<bool> ProductUnique(string productName)
        {
            return await _inventoryDatabaseContext.Products.AnyAsync(entity => entity.Name == productName) == false;
        }
    }
}
