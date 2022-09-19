using Microsoft.AspNetCore.Mvc;
using LongToShortUrl.Domain;
using LongToShortUrl.Domain.Services;

namespace LongToShortUrl.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IUrlShorteningService _urlService;

        public UrlController(ApplicationContext context,IUrlShorteningService urlService)
        {
            _context = context;
            _urlService = urlService;
        }

        [HttpPost]
        public async Task<ActionResult<Url>> Post([FromBody]Url url)
        {
            //Constructing short url using db column count as a key to generate short url code
            Url resultUrl = _urlService.CreateShortUrl(url.LongUrl, _context.Urls.Count());

            //Checking if current url is in the db already
            var dbUrl = _context.Urls.Where(u => u.LongUrl == resultUrl.LongUrl).FirstOrDefault();
            if (dbUrl != null) return Ok(dbUrl);

            //Checking if passed url was invalid
            if(resultUrl == null) return BadRequest("URL is not valid");

            //Updating db
            await _context.Urls.AddAsync(resultUrl);
            await _context.SaveChangesAsync();
            return Ok(resultUrl);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Url>> Delete(int id)
        {
            Url url = _context.Urls.FirstOrDefault(x => x.Id == id);
            if (url == null) return NotFound();
            _context.Urls.Remove(url);
            await _context.SaveChangesAsync();
            return Ok(url);
        }
       
    }
}
