using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;
public sealed class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,IdentityUserClaim<Guid>,AppUserRole,IdentityUserLogin<Guid>,IdentityRoleClaim<Guid>,IdentityUserToken<Guid>>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<IdentityUserClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserLogin<Guid>>();
        modelBuilder.Ignore<IdentityRoleClaim<Guid>>();
        modelBuilder.Ignore<IdentityUserToken<Guid>>();

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
    }

    public DbSet<Course> Courses { get; set; }
}
