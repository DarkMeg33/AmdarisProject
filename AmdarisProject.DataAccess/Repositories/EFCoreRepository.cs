using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmdarisProject.DataAccess.Repositories
{
    public class EFCoreRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        private readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public EFCoreRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdWithIncludeAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> entities = _dbSet;

            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }

            var query = entities;
            return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
