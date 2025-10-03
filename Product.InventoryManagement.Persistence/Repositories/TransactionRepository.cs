using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Domain.Entities;
using Product.InventoryManagement.Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Persistence.Repositories
{
    public class TransactionRepository : GenericRepository<InventoryTransaction>, ITransactionRepository
    {
        private readonly InventoryDatabaseContext _databaseContext;
        public TransactionRepository(InventoryDatabaseContext inventoryDatabaseContext) : base(inventoryDatabaseContext)
        {
            _databaseContext = inventoryDatabaseContext;
        }
    }
}
