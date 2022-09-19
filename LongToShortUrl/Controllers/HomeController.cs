using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LongToShortUrl.Domain;

namespace LongToShortUrl.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;
        public HomeController(ApplicationContext context) 
        {
            _context = context;
        }

        [Route("{urlCode}")]
        public async Task<RedirectResult> Index(string UrlCode)
        {
            //if the url exists in the database, redirects to the long url, otherwise redirects to the home page
            Url? url = await _context.Urls.FirstOrDefaultAsync(u => u.UrlCode == UrlCode);
            if (url == null) return Redirect("~/");
            return Redirect(url.LongUrl);
        }
    }
}
