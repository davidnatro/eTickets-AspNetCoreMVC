using System.Collections.Generic;
using System.Threading.Tasks;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        private readonly AppDbContext _dbContext;

        public EntityBaseRepository(AppDbContext context) 
            => _dbContext = context;

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbContext.Set<T>().ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FirstOrDefaultAsync(actor => actor.Id == id);

        public async Task AddAsync(T entity) => await _dbContext.Set<T>().AddAsync(entity);
        

        public Task UpdateAsync(int id, T entity)
        {
            EntityEntry entry = _dbContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(actor => actor.Id == id);
            EntityEntry entry = _dbContext.Entry<T>(entity);
            entry.State = EntityState.Deleted;
        }
    }
}