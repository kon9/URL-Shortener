using LongToShortUrl.Core.Models;
using LongToShortUrl.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LongToShortUrl.Infrastructure;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    public DbSet<Url> Url { get; set; }
    public DbSet<LinkStatistic> LinkStatistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<LinkStatistic>()
            .HasOne(l => l.Url)
            .WithMany(u => u.LinkStatistics)
            .HasForeignKey(l => l.UrlId);
    }
}


