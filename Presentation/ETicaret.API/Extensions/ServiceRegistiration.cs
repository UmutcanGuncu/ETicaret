using ETicaret.Domain.Entities;
using ETicaret.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.API.Extensions;

public static class ServiceRegistiration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddOpenApi();
        // DbContext ayarlaması yapıldı 
        services.AddDbContext<ETicaretDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddIdentity<AppUser, AppRole>(opt => // identity db context ayarları yapıldı
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 7;
            })
            .AddEntityFrameworkStores<ETicaretDbContext>()
            .AddRoles<AppRole>()
            .AddDefaultTokenProviders();
        return services;
    }
}