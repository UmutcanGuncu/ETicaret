using System.Security.Claims;
using ETicaret.Domain.Entities;

namespace ETicaret.Application.Abstractions;

public interface IRoleService
{
    Task CreateRoleAsync(string roleName);
    Task<bool> AssignRoleToUserAsync(AppUser user, string roleName);
    Task<IEnumerable<Claim>> GetRoleClaimsAsync(string userId);
}