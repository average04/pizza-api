namespace Pizza.Application.Service;

public class PaginatedResult<T>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public int? TotalPages { get; set; }
    public List<T> Items { get; set; } = new List<T>();

    public PaginatedResult(List<T> items, int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        Items = items;
    }
}