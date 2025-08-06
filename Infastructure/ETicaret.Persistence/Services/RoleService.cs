using System.Security.Claims;
using ETicaret.Application.Abstractions;
using ETicaret.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ETicaret.Persistence.Services;

public class RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager) : IRoleService
{
    public async Task CreateRoleAsync(string roleName)
    {
        if (!await roleManager.RoleExistsAsync(roleName))  //ilgili rol bulunamazsa rolü oluşturur
            await roleManager.CreateAsync(new AppRole() { Name = roleName });
    }

    public async Task<bool> AssignRoleToUserAsync(AppUser user, string roleName)
    {
        if (user is null)
            return false; // verilen kullanıcı bilgisi bulunamazsa false döndrür
        if(!await roleManager.RoleExistsAsync(roleName)) 
            await CreateRoleAsync(roleName);// ilgili rol bulunamazsa rolü oluşturur
        var userRoles = await userManager.GetRolesAsync(user); // kullanıcının rolleri listelenir
        if(userRoles.Contains(roleName)) //listelenen roller arasında varsa true döndürür
            return true;
        var result = await userManager.AddToRoleAsync(user, roleName); //kullanıcıya rol ataması yapılır
        return result.Succeeded;
    }

    public async Task<IEnumerable<Claim>> GetRoleClaimsAsync(string userId)
    {
       var user = await userManager.FindByIdAsync(userId); // kullanıcı verilen id ile aranır
       if (user != null) // kullanıcı bulunursa ilgili işlemler yapılır
       {
           var roles = await userManager.GetRolesAsync(user); // kullanıcı rolleri listelenşr
           var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
           // roller claim'e dönüştürülür
           return roleClaims;
       }
       return new List<Claim>(); // boş liste döndürülür kullanıcı bilgisi bulunamazsa
    }
}