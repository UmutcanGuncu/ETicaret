using ETicaret.Application.CQRS.Commands.Auths;
using ETicaret.Application.CQRS.Results;
using ETicaret.Application.DTOs.Auths.Requests;
using ETicaret.Application.DTOs.Auths.Results;
using Riok.Mapperly.Abstractions;

namespace ETicaret.Application.Configurations;
[Mapper]
public static partial class ModelMapper
{
    public static partial RegisterDto MapRegisterDto(RegisterUserCommandRequest request);
    public static partial RegisterUserCommandResult MapRegisterUserCommandResult(RegisterResultDto registerResultDto);
}