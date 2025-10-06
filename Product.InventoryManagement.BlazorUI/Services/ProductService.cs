using Product.InventoryManagement.Application.DTOs;
using Product.InventoryManagement.BlazorUI.Services.Contracts;

namespace Product.InventoryManagement.BlazorUI.Services
{

    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDto>>("https://localhost:7067/api/Product") ?? [];
        }
    }

}
