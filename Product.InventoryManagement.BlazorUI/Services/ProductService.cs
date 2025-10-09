using Microsoft.AspNetCore.Http;
using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.BlazorUI.Models;
using Product.InventoryManagement.BlazorUI.Services.Contracts;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ProductItem = Product.InventoryManagement.Domain.Entities.Product;

namespace Product.InventoryManagement.BlazorUI.Services
{

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<ApiResponse<ProductItem>> GetProductAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/product/{id}");

            return await response.ToApiResponseAsync<ProductItem>();
        }

        public async Task<PaginationResult<ProductItem>> GetProductsAsync(int pageNumber, int pageSize)
        {
            return await _httpClient.GetFromJsonAsync<PaginationResult<ProductItem>>($"api/Product?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<ApiResponse<ProductItem>> AddProductAsync(ProductFormModel product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product", product);

            return await response.ToApiResponseAsync<ProductItem>();
        }

        public async Task<ApiResponse<ProductItem>> UpdateProductAsync(UpdateProductFormModel product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/product/{product.Id}", product);

            return await response.ToApiResponseAsync<ProductItem>();
        }

        public async Task<ApiResponse<ProductItem>> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/product/{id}");
            return await response.ToApiResponseAsync<ProductItem>();
        }
    }

}
