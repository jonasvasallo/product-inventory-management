using Microsoft.AspNetCore.Mvc;

namespace Product.InventoryManagement.Api.Models
{
    public class ErrorResponseDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
