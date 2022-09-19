using LongToShortUrl.Domain.URLHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LongToShortUrl.Domain.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        
        public Url? CreateShortUrl(string longUrl,int seed)
        {
            //Checks if there is a protocol in the link, if not adds it
            if (!(longUrl.StartsWith("http://") || (longUrl.StartsWith("https://"))))
            {
                longUrl = longUrl.Insert(0, "https://");
            }

            //Generating short id and constructing short url
            if (UrlHelper.IsUrlValid(longUrl))
            {
                Url url = new Url();
                string UrlCode = ConversionAlgorithm.Encode(seed);
                url.LongUrl = longUrl;
                url.UrlCode = UrlCode;
                url.ShortUrl += "/" + UrlCode;
                url.CreationDate = DateTime.Now;
                return url;
            }
            return null;
        }
        
    }
}
