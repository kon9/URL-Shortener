using LongToShortUrl.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LongToShortUrl.Data.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    public DbSet<Url> Urls => Set<Url>();
}


