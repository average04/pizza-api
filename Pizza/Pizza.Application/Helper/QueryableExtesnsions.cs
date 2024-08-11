using Pizza.Application.Service;

namespace Pizza.Application.Helper;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> PaginateAsync<T>(
      this IQueryable<T> source,
      int? pageNumber,
      int? pageSize)
    {
        var count = await source.CountAsync();

        // If pageNumber or pageSize is null, return all items
        if (!pageNumber.HasValue || !pageSize.HasValue)
        {
            var allItems = await source.ToListAsync();
            return new PaginatedResult<T>(allItems, count, 1, count);
        }

        var items = await source
            .Skip((pageNumber.Value - 1) * pageSize.Value)
            .Take(pageSize.Value)
            .ToListAsync();

        return new PaginatedResult<T>(items, count, pageNumber.Value, pageSize.Value);
    }
}