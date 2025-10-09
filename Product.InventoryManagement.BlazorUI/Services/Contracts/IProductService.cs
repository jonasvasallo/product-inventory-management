using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.BlazorUI.Models;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.BlazorUI.Services.Contracts
{
    public interface IProductService
    {
        Task<PaginationResult<ProductItem>> GetProductsAsync(int pageNumber, int pageSize);

        Task<ProductItem> GetProductAsync(int id);

        Task<HttpResponseMessage> AddProductAsync(ProductFormModel product);
        Task<HttpResponseMessage> UpdateProductAsync(UpdateProductFormModel product);

        Task<HttpResponseMessage> DeleteProductAsync(int id);
    }
}
