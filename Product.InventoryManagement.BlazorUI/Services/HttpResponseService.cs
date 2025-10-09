using Product.InventoryManagement.BlazorUI.Models;

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
                        apiResponse.Data = await response.Content.ReadFromJsonAsync<T>();
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
