using ETicaret.Application.CQRS.Results.Auths;
using MediatR;

namespace ETicaret.Application.CQRS.Commands.Auths;

public class LoginUserCommandRequest : IRequest<LoginUserCommandResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
}