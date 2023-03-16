using LongToShortUrl.Service;
using Microsoft.AspNetCore.Mvc;

namespace LongToShortUrl.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IURLShortenerService _urlShortenerService;
        public HomeController(IURLShortenerService urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
        }


        public IActionResult Index()
        {
            var urls = _urlShortenerService.GetAll();
            return View(urls);
        }
    }
}
