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
        
        public Task<ProductItem> GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductItem>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductExists(string productName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
