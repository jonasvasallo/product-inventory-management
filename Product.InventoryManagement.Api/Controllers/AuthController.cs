using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.InventoryManagement.Application.Contracts.Auth;
using Product.InventoryManagement.Application.Models;

namespace Product.InventoryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthRequest request)
        {
            return Ok(await _authService.Login(request));
        }
    }

}
