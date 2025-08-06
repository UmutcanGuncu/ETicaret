using ETicaret.Application.Abstractions;
using ETicaret.Application.DTOs.Auths.Requests;
using ETicaret.Application.DTOs.Auths.Results;

namespace ETicaret.Persistence.Services;

public class AuthService : IAuthService
{
    public Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto)
    {
        throw new NotImplementedException();
    }

    public Task<LoginResultDto> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}