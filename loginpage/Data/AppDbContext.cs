using System.Collections.Immutable;
using loginpage.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace loginpage.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<User>(entity => 
        {
            entity.HasIndex(u => u.UserName).IsUnique();
            entity.HasIndex(u => u.NormalizedUserName).IsUnique();
            entity.HasIndex(u => u.Email).IsUnique();
            entity.HasIndex(u => u.NormalizedEmail).IsUnique();
            entity.HasIndex(u => u.PhoneNumber).IsUnique();
        });
    }
}