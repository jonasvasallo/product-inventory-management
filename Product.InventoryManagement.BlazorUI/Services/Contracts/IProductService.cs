using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.BlazorUI.Models;

namespace Product.InventoryManagement.BlazorUI.Services.Contracts
{
    public interface IProductService
    {
        Task<List<Domain.Entities.Product>> GetProductsAsync();
        Task<Domain.Entities.Product> GetProductAsync(Guid id);

        Task<HttpResponseMessage> AddProductAsync(ProductFormModel product);
        Task<HttpResponseMessage> UpdateProductAsync(UpdateProductFormModel product);

        Task<HttpResponseMessage> DeleteProductAsync(Guid id);
    }
}
