using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.InventoryManagement.Application.Contracts.Persistence;
using Product.InventoryManagement.Domain.Common;
using Product.InventoryManagement.Persistence.DatabaseContext;

namespace Product.InventoryManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly InventoryDatabaseContext _inventoryDatabaseContext;

        public GenericRepository(InventoryDatabaseContext inventoryDatabaseContext)
        {
            _inventoryDatabaseContext = inventoryDatabaseContext;
        }
        public async Task CreateAsync(T entity)
        {
            await _inventoryDatabaseContext.AddAsync(entity);
            await _inventoryDatabaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _inventoryDatabaseContext.Remove(entity);
            await _inventoryDatabaseContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _inventoryDatabaseContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _inventoryDatabaseContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _inventoryDatabaseContext.Entry(entity).State = EntityState.Modified;
            await _inventoryDatabaseContext.SaveChangesAsync();
        }

        Task IGenericRepository<T>.CreateAsync(T entity)
        {
            return CreateAsync(entity);
        }
    }
}
