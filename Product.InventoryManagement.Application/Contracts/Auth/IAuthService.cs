using Product.InventoryManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Contracts.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);

    }
}
