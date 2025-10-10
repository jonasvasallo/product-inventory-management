using Product.InventoryManagement.BlazorUI.Models;
using System.Text.Json;

namespace Product.InventoryManagement.BlazorUI.Services
{
    public static class HttpResponseService
    {
        public static async Task<ApiResponse<T>> ToApiResponseAsync<T>(this HttpResponseMessage response) where T : class
        {
            {
                var apiResponse = new ApiResponse<T>
                {
                    StatusCode = response.StatusCode,
                    Success = response.IsSuccessStatusCode
                };

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        // added check for handling requests without content (e.g. delete endpoint for products)
                        if (!string.IsNullOrWhiteSpace(content))
                        {
                            apiResponse.Data = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });
                        }
                        apiResponse.Message = "Request successful";
                    }
                    catch (Exception ex)
                    {
                        apiResponse.Message = $"Deserialization error: {ex.Message}";
                        apiResponse.Success = false;
                    }
                }
                else
                {
                    apiResponse.Message = await response.Content.ReadAsStringAsync();
                }

                return apiResponse;
            }
        }
    }
}
