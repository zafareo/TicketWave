using Application.Commons.Models;
using MediatR;

namespace Application.UseCases.Rows.Queries;

public class GetAllRowsQuery : IRequest<PaginatedList<GetAllRowsQueryResponse>>
{
    public string? SearchingText { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
