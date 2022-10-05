using AmdarisProject.Domain;
using System.Linq.Expressions;

namespace AmdarisProject.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(T entity);
    }
}
