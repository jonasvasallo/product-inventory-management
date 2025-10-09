using Microsoft.AspNetCore.Http;
using System.Net;
namespace Product.InventoryManagement.BlazorUI.Models
{
    public class ApiResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

    }
}
