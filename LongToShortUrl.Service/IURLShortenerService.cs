using LongToShortUrl.Domain.Models;

namespace LongToShortUrl.Service
{
    public interface IURLShortenerService
    {
        string GenerateShortenedURL(string originalURL);
        void SaveURL(Url urlShortener);
        string GetOriginalURL(string shortenedURL);
        public List<Url> GetAll();
    }
}
