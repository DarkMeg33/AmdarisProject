using AmdarisProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace AmdarisProject.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationResult<T>> GetPaginationResultAsync<T>(this IQueryable<T> query,
            PaginationRequest paginationRequest)
        {
            var totalItems = await query.CountAsync();
            query = query.Paginate(paginationRequest);

            query = query.Sort(paginationRequest.SortingRequest);

            var items = await query.ToListAsync();

            return new PaginationResult<T>()
            {
                PageIndex = paginationRequest.PageIndex,
                PageSize = paginationRequest.PageSize,
                TotalItems = totalItems,
                Items = items
            };
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationRequest paginationRequest)
        {
            return query.Skip(paginationRequest.PageIndex * paginationRequest.PageSize).Take(paginationRequest.PageSize);
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, SortingRequest sortingRequest)
        {
            if (!string.IsNullOrWhiteSpace(sortingRequest.ColumnName))
            {
                query = query.OrderBy(sortingRequest.ColumnName + " " 
                    + (sortingRequest.SortDirection == SortDirection.Ascending ? "asc" : "desc"));
            }

            return query;
        }
    }
}
