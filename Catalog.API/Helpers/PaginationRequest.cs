namespace Catalog.API.Helpers;

public record PaginationRequest(int PageSize = 6, int PageIndex = 0);