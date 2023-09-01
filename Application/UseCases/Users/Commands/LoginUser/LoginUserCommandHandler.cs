using Application.Commons.Exceptions;
using Application.Commons.Jwt.Interfaces;
using Application.Commons.Jwt.Models;
using MediatR;

namespace Application.UseCases.Users.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, TokenResponse>
{
    private readonly IJwtToken _jwtToken;
    private readonly IUserRefreshToken _userRefreshToken;

    public LoginUserCommandHandler(IJwtToken jwtToken, IUserRefreshToken userRefreshToken)
    {
        _jwtToken = jwtToken;
        _userRefreshToken = userRefreshToken;

    }

    public async Task<TokenResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var authenUser = await _userRefreshToken.AuthenAsync(request);
        if (authenUser is null)
            throw new UnauthorizedException(request.Username, request.Password);

        var tokenResponse = await _jwtToken.CreateTokenAsync(authenUser.Username, authenUser.Id.ToString(), authenUser.Roles, cancellationToken);

        return tokenResponse;
    }
}