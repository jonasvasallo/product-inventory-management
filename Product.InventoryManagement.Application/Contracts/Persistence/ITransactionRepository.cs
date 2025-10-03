using Product.InventoryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.InventoryManagement.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IGenericRepository<InventoryTransaction>
    {
    }
}
