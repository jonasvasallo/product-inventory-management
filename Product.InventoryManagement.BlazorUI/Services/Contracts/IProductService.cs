using Product.InventoryManagement.Application.DTOs;

namespace Product.InventoryManagement.BlazorUI.Services.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProductsAsync();
    }
}
