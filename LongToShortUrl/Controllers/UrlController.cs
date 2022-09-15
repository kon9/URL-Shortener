using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using LongToShortUrl.Models;
using System.Net;

namespace LongToShortUrl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly IServer _server;
        private readonly ApplicationContext _context;
        public UrlController(ApplicationContext context, IServer server)
        {
            _context = context;
            _server = server;
        }

        [HttpPost]
        public async Task<ActionResult<Url>> Post(Url url)
        {
            //Checks if there is a protocol in the link, if not adds it
            if (!(url.LongUrl.StartsWith("http://") || (url.LongUrl.StartsWith("https://"))))
            {
                url.LongUrl = url.LongUrl.Insert(0, "https://");
            }

            //Checking if current url is in the db already
            var dbUrl = _context.Urls
                    .Where(u => u.LongUrl == url.LongUrl)
                    .FirstOrDefault();
            if (dbUrl != null) return Ok(dbUrl);

            if (UrlIsValid(url.LongUrl)) {
                //Generating short id and constructing short url
                string BaseUrl = String.Join(String.Empty, _server.Features.Get<IServerAddressesFeature>().Addresses);
                string UrlCode = ConversionAlgorithm.Encode(_context.Urls.Count());

                url.UrlCode = UrlCode;
                url.ShortUrl = BaseUrl + "/" + UrlCode;
                url.CreationDate = DateTime.Now;

                await _context.Urls.AddAsync(url);
                await _context.SaveChangesAsync();
                return Ok(url);
            }
            return BadRequest(url);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Url>> Delete(int id)
        {
            Url url = _context.Urls.FirstOrDefault(x => x.Id == id);
            if (url == null)
            {
                return NotFound();
            }
            _context.Urls.Remove(url);
            await _context.SaveChangesAsync();
            return Ok(url);
        }

        protected internal bool UrlIsValid(string url)
        {
            Uri uri = new Uri(url);

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
