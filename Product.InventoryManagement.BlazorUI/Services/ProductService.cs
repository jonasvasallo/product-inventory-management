using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.BlazorUI.Models;
using Product.InventoryManagement.BlazorUI.Services.Contracts;
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

        public async Task<ProductItem> GetProductAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductItem>($"api/product/{id}");
        }

        public async Task<PaginationResult<ProductItem>> GetProductsAsync(int pageNumber, int pageSize)
        {
            return await _httpClient.GetFromJsonAsync<PaginationResult<ProductItem>>($"api/Product?pageNumber={pageNumber}&pageSize={pageSize}");
        }

        public async Task<HttpResponseMessage> AddProductAsync(ProductFormModel product)
        {
            var response = await _httpClient.PostAsJsonAsync("api/product", product);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(UpdateProductFormModel product)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/product/{product.Id}", product);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/product/{id}");
            return response;
        }
    }

}
