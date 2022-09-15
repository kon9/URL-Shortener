using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LongToShortUrl.Models;

namespace LongToShortUrl.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        [Route("{urlCode}")]
        public async Task<RedirectResult> Index(string UrlCode)
        {
            //if the url exists in the database, redirects to the long url, otherwise redirects to the home page
            Url? url = await db.Urls.FirstOrDefaultAsync(u => u.UrlCode == UrlCode);
            if (url == null) return Redirect("~/");
            return Redirect(url.LongUrl);
        }
    }
}
