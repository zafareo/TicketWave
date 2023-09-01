using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.UseCases.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid[]? RoleIds { get; set; }
        public IFormFile? ProfilePicture { get; set; }
    }
}
