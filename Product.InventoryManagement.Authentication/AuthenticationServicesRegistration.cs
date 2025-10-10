using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Product.InventoryManagement.Application.Contracts.Auth;
using Product.InventoryManagement.Application.Models;
using Product.InventoryManagement.Authentication.DatabaseContext;
using Product.InventoryManagement.Authentication.Models;
using Product.InventoryManagement.Authentication.Services;
using System.Runtime.CompilerServices;
using System.Text;

namespace Product.InventoryManagement.Authentication
{
    public static class AuthenticationServicesRegistration
    {
        public static IServiceCollection ConfigureAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<ProductInventoryManagementIdentityDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("InventoryDatabaseConnectionString"), new MySqlServerVersion(new Version(9, 4, 0)));
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ProductInventoryManagementIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            return services;
        }
    }
}
