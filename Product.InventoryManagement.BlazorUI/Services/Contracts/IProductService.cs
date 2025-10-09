using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.BlazorUI.Models;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.BlazorUI.Services.Contracts
{
    public interface IProductService
    {
        Task<PaginationResult<ProductItem>> GetProductsAsync(int pageNumber, int pageSize);

        Task<ApiResponse<ProductItem>> GetProductAsync(int id);

        Task<ApiResponse<ProductItem>> AddProductAsync(ProductFormModel product);
        Task<ApiResponse<ProductItem>> UpdateProductAsync(UpdateProductFormModel product);

        Task<ApiResponse<ProductItem>> DeleteProductAsync(int id);
    }
}
