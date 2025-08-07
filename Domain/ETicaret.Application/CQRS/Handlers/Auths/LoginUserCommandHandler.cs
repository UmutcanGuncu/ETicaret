using ETicaret.Application.Abstractions;
using ETicaret.Application.Configurations;
using ETicaret.Application.CQRS.Commands.Auths;
using ETicaret.Application.CQRS.Results.Auths;
using MediatR;

namespace ETicaret.Application.CQRS.Handlers.Auths;

public class LoginUserCommandHandler(IAuthService authService) : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResult>
{
    public async Task<LoginUserCommandResult> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
    {
        var loginDto = ModelMapper.MapLoginDto(request);
        var loginResultDto = await authService.LoginAsync(loginDto);
        return ModelMapper.MapLoginUserCommandResult(loginResultDto);
    }
}