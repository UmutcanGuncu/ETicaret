using ETicaret.Application.Abstractions;
using ETicaret.Application.Configurations;
using ETicaret.Application.CQRS.Commands.Auths;
using ETicaret.Application.CQRS.Results;
using MediatR;

namespace ETicaret.Application.CQRS.Handlers.Auths;

public class RegisterUserCommandHandler(IAuthService authService) : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResult>
{
    public async Task<RegisterUserCommandResult> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var registerDto = ModelMapper.MapRegisterDto(request);
        var registerResultDto =  await authService.RegisterAsync(registerDto);
        return ModelMapper.MapRegisterUserCommandResult(registerResultDto);

    }
}