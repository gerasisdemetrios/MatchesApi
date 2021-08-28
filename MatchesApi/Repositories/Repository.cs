using Matches.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matches.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MatchContext _context;
        public Repository(MatchContext context)
        {
            _context = context;
        }
        public async Task<T> SaveAsync(T entity)
        {
            var createdEntity = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return createdEntity.Entity;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await  _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
