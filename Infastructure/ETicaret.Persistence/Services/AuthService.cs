using ETicaret.Application.Abstractions;
using ETicaret.Application.DTOs.Auths.Requests;
using ETicaret.Application.DTOs.Auths.Results;
using ETicaret.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ETicaret.Persistence.Services;

public class AuthService(UserManager<AppUser> userManager, IRoleService roleService) : IAuthService
{
    public async Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto)
    {
        AppUser user = new()
        {
            Email = registerDto.Email,
            UserName = registerDto.Email,
            PhoneNumber = registerDto.PhoneNumber,
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
        };
        var result = await userManager.CreateAsync(user, registerDto.Password);
        if (result.Succeeded)
        {
            await roleService.AssignRoleToUserAsync(user,"User");
            return new()
            {
                Success = true,
                Message = "Kullanıcı Başarıyla Oluşturuldu"
            };
        }

        return new()
        {
            Success = false,
            Message = result.Errors.First().Description
        };
    }

    public Task<LoginResultDto> LoginAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}