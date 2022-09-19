using Microsoft.EntityFrameworkCore;
using LongToShortUrl.Domain;

namespace LongToShortUrl
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
            
        public DbSet<Url> Urls => Set<Url>();
    }

}

