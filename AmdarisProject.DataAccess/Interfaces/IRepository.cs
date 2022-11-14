using AmdarisProject.Domain;
using System.Linq.Expressions;
using AmdarisProject.Common.Models;

namespace AmdarisProject.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IList<T>> GetAllAsync();
        Task<PaginationResult<T>> GetPagedAsync(PaginationRequest paginationRequest);
        Task<IList<T>> GetByQueryAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdWithIncludeAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
    }
}
