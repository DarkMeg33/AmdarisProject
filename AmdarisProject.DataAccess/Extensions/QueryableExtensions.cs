using AmdarisProject.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Text;

namespace AmdarisProject.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationResult<T>> GetPaginationResultAsync<T>(this IQueryable<T> query,
            PaginationRequest paginationRequest)
        {
            query = query.ApplyFilters(paginationRequest.FilterRequest);

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

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, FilterRequest filterRequest)
        {
            var predicate = new StringBuilder();
            var filters = filterRequest.Filters;

            for (int i = 0; i < filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" AND ");
                }
                predicate.Append(filters[i].Path + $" (@{i})");
            }

            if (filters.Any())
            {
                var propertyValues = filters.Select(filter => filter.Value).ToArray();

                query = query.Where(predicate.ToString(), propertyValues);
            }

            return query;
        }
    }
}
