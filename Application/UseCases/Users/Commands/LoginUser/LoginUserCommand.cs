
using Application.Commons.Jwt.Models;
using MediatR;

namespace Application.UseCases.Users.Commands.LoginUser;

public class LoginUserCommand : IRequest<TokenResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
}
