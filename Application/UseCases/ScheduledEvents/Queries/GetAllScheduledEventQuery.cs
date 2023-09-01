using Application.Commons.Models;
using MediatR;
namespace Application.UseCases.ScheduledEvents.Queries;
public class GetAllScheduledEventQuery : IRequest<PaginatedList<GetAllScheduledEventQueryResponse>>
{
    public string? SearchingText { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}
