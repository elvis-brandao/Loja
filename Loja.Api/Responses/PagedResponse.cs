namespace Loja.Api.Responses;

public class PagedResponse<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int TotalItems { get; set; }

    public int TotalPages { get; set; }

    public List<T> Data { get; set; } = [];
}