using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.Application.Contracts.Persistence
{
    public interface IProductRepository : IGenericRepository<ProductItem>
    {
        Task<List<ProductItem>> GetProducts();

        Task<ProductItem> GetProduct(Guid id);
        Task<bool> ProductExists(string productName);

    }
}
