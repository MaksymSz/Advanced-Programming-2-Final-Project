using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LoginTest.Models;

namespace LoginTest.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<LoginTest.Models.Event> Events { get; set; } = default!;
    public DbSet<LoginTest.Models.AspNetUser> AspNetUser { get; set; } = default!;
    public DbSet<LoginTest.Models.Participation> Participation { get; set; } = default!;
    public DbSet<LoginTest.Models.Friendship> Friendship { get; set; } = default!;
}