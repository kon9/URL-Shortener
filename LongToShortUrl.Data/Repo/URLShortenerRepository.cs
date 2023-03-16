using LongToShortUrl.Data.Context;
using LongToShortUrl.Domain.Models;

namespace LongToShortUrl.Data.Repo
{
    public class URLShortenerRepository : IURLShortenerRepository
    {

        private readonly ApplicationContext _context;

        public URLShortenerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Exists(string longUrl)
        {
            return _context.Urls.Any(x => x.LongUrl == longUrl);
        }

        public List<Url> GetAll()
        {
            return _context.Urls.ToList();
        }

        public Url GetByLongURL(string longUrl) => _context.Urls.FirstOrDefault(x => x.LongUrl == longUrl);

        public Url GetByShortURL(string shortenedURL) => _context.Urls.FirstOrDefault(x => x.ShortUrl == shortenedURL);

        public void Save(Url urlShortener)
        {
            _context.Urls.Add(urlShortener);
            _context.SaveChanges();
        }
    }
}
