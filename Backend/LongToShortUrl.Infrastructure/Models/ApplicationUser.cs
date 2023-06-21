using LongToShortUrl.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace LongToShortUrl.Infrastructure.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Url> CreatedUrls { get; set; }
}