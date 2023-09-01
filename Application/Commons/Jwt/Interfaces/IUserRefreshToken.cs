using Application.UseCases.Users.Commands.LoginUser;
using Domain.Identity;
namespace Application.Commons.Jwt.Interfaces;

public interface IUserRefreshToken
{
    ValueTask<UserRefreshToken> AddOrUpdateRefreshToken(UserRefreshToken refreshToken, CancellationToken cancellationToken = default);
    ValueTask<User> AuthenAsync(LoginUserCommand user);
    ValueTask<bool> DeleteUserRefreshTokens(string username, string refreshToken, CancellationToken cancellationToken = default);
    ValueTask<UserRefreshToken> GetSavedRefreshTokens(string username, string refreshtoken);
}
