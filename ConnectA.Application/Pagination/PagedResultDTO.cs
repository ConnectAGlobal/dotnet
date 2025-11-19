using ConnectA.Application.DTOs;

namespace ConnectA.Application.Pagination;

public class PagedResultDTO<T>
{
    public IEnumerable<T> Items { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public List<HateoasLink> Links { get; set; }
}