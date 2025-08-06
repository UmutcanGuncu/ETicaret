using ETicaret.API.Localizations;
using ETicaret.Application.Abstractions;
using ETicaret.Domain.Entities;
using ETicaret.Persistence.Contexts;
using ETicaret.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaret.API.Extensions;

public static class ServiceRegistiration
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddOpenApi();
        // cors politikası ayarlaması gerçekleştirildi
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });
        // MediatR ayarlaması
        services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(
            typeof(Program).Assembly));
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
            .AddErrorDescriber<LocalizationIdentityErrorDescriber>()
            .AddDefaultTokenProviders();
        
        // Dependecy injection ayarlamaları
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGenericService, GenericService>(); // özelleştirme yapılacak
        services.AddScoped<ITokenService, TokenService>();
        return services;
    }
}