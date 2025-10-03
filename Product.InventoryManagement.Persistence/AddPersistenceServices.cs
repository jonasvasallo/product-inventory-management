using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Persistence.DatabaseContext;
using Product.InventoryManagement.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Persistence
{
    public static class AddPersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {

            services.AddDbContext<InventoryDatabaseContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("InventoryDatabaseConnectionString"), new MySqlServerVersion(new Version(9, 4, 0)));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            // TODO: Add entity repositories here
            // <Interface, Implementation>
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();


            return services;
        }
    }
}
