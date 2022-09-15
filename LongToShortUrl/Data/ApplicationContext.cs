using Microsoft.EntityFrameworkCore;
using LongToShortUrl.Models;

namespace LongToShortUrl
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
            
        public DbSet<Url> Urls => Set<Url>();
    }

}

