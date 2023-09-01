using Application.Commons.Jwt.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Users.Commands.RegisterUser;

public class RegisterUserCommand : IRequest<TokenResponse>
{
    public string FullName { get; set; }
    public string Username { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public IFormFile? ProfilePicture { get; set; }
}
