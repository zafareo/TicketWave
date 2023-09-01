using Application.Commons.Models;
using Application.UseCases.Users.Response;
using MediatR;
namespace Application.UseCases.Users.Queries.GetAll;

public record GetAllUserQuery : IRequest<PaginatedList<UserResponse>>
{
    public string? SearchingText { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
