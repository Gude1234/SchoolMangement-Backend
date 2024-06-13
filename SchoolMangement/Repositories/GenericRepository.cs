using Microsoft.EntityFrameworkCore;
using SchoolMangement.Contracts;
using SchoolMangement.Data;

namespace SchoolMangement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await GetAsync(id);
            _context.Set<T>().Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exsits(int id)
        {
            var data = await GetAsync(id);
            return data != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
