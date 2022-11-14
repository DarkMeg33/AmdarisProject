using AmdarisProject.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationResult<T>> GetPaginationResultAsync<T>(this IQueryable<T> query,
            PaginationRequest paginationRequest)
        {
            var totalItems = await query.CountAsync();
            query = query.Paginate(paginationRequest);

            return new PaginationResult<T>()
            {
                PageIndex = paginationRequest.PageIndex,
                PageSize = paginationRequest.PageSize,
                TotalItems = totalItems,
                Items = await query.ToListAsync()
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationRequest paginationRequest)
        {
            return query.Skip(paginationRequest.PageIndex * paginationRequest.PageSize).Take(paginationRequest.PageSize);
        }
    }
}
