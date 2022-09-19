using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongToShortUrl.Domain.Services
{
    public interface IUrlShorteningService
    {
        Url CreateShortUrl (string longUrl,int seed);
    }
}
