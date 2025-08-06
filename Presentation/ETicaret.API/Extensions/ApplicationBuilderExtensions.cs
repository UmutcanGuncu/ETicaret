using ETicaret.Application.Abstractions;
using ETicaret.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ETicaret.API.Extensions;

// uygulama build edilme esnasında yapılacak işlemler
public static class ApplicationBuilderExtensions
{
    public static async Task ExecuteAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var roleService = scope.ServiceProvider.GetRequiredService<IRoleService>();
        // uygulama çalıştırılınca Admin user ve support rolleri bulunmuyorsa roller eklenecek
        await roleService.CreateRoleAsync("Admin"); 
        await roleService.CreateRoleAsync("User");
        await roleService.CreateRoleAsync("Support");
        
    }
}