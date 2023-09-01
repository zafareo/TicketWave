using Application.Commons.Models;
using MediatR;

namespace Application.UseCases.Venues.Queries;
public class GetAllVenuesQuery : IRequest<PaginatedList<GetAllVenueQueryResponse>>
{
    public string? SearchingText { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
