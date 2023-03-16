using LongToShortUrl.Domain.Models;
using LongToShortUrl.Service;
using Microsoft.AspNetCore.Mvc;

namespace LongToShortUrl.Controllers
{
    [ApiController]
    [Route("/")]
    public class URLShortenerController : Controller
    {
        private readonly IURLShortenerService _urlShortenerService;

        public URLShortenerController(IURLShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var urls = _urlShortenerService.GetAll();
            return View(urls);
        }

        [HttpPost]
        public IActionResult Create(string longUrl)
        {
            var Url = new Url
            {
                LongUrl = longUrl,
                ShortUrl = _urlShortenerService.GenerateShortenedURL(longUrl),
                CreationDate = DateTime.Now
            };
            _urlShortenerService.SaveURL(Url);
            return View("Create", Url); ;
        }

        [Route("{shortenedURL}")]
        public ActionResult Redirect(string shortenedURL)
        {
            var originalURL = _urlShortenerService.GetOriginalURL(shortenedURL);

            if (string.IsNullOrEmpty(originalURL))
            {
                return NotFound();
            }

            return Redirect(originalURL);
        }

        /*[HttpDelete("{id}")]
        public async Task<ActionResult<Url>> Delete(int id)
        {
           *//* Url url = _context.Urls.FirstOrDefault(x => x.Id == id);
            if (url == null) return NotFound();
            _context.Urls.Remove(url);
            await _context.SaveChangesAsync();
            return Ok(url);*//*
        }*/

    }
}
