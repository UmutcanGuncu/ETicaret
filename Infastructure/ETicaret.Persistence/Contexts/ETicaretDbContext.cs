using ETicaret.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Persistence.Contexts;

public class ETicaretDbContext : IdentityDbContext<AppUser, AppRole, Guid>
{
    public ETicaretDbContext(DbContextOptions<ETicaretDbContext> options) : base(options)
    {
        
    }
    
}