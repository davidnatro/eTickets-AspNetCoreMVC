using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorService : IActorsService
    {
        private AppDbContext _dbContext;

        public ActorService(AppDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _dbContext.Actors.ToListAsync();
            return result;
        }
        
        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _dbContext.Actors.FirstOrDefaultAsync(actor => actor.Id == id);
        }

        public async Task AddAsync(Actor actor)
        {
            await _dbContext.Actors.AddAsync(actor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _dbContext.Update(newActor);
            await _dbContext.SaveChangesAsync();
            return newActor;  
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await _dbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _dbContext.Actors.Remove(actor);
            await _dbContext.SaveChangesAsync();
        }
    }
}