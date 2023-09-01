using Application.Commons.Jwt.Models;
using Domain.Identity;
using System.Security.Claims;


namespace Application.Commons.Jwt.Interfaces;

public interface IJwtToken
{
    ValueTask<TokenResponse> CreateTokenAsync(string userName, string UserId, ICollection<Role> roles, CancellationToken cancellationToken = default);
    ValueTask<ClaimsPrincipal> GetPrincipalFromExpiredToken(string token);
    ValueTask<string> GenerateRefreshTokenAsync(string userName);
}
