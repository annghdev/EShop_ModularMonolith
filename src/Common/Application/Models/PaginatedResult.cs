namespace Common;

public class PaginatedResult<T>
{
    public PaginatedResult(int pageNumber, int pageSize, IEnumerable<T> items, int totalItems)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        Items = items;
        TotalItems = totalItems;
    }

    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public IEnumerable<T> Items { get; init; } = [];
    public int TotalItems { get; init; }
    public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
}
