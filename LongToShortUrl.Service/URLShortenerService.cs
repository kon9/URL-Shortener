using LongToShortUrl.Data.Repo;
using LongToShortUrl.Domain.Models;
using LongToShortUrl.Domain.URLHelpers;

namespace LongToShortUrl.Service
{
    public class URLShortenerService : IURLShortenerService
    {
        private readonly IURLShortenerRepository _urlShortenerRepository;

        public URLShortenerService(IURLShortenerRepository urlShortenerRepository)
        {
            _urlShortenerRepository = urlShortenerRepository;
        }
        public string GenerateShortenedURL(string originalURL)
        {
            if (_urlShortenerRepository.Exists(originalURL)) return _urlShortenerRepository.GetByLongURL(originalURL).ShortUrl;
            var rand = new Random();
            return ConversionAlgorithm.Encode(rand.Next());
        }

        public string GetOriginalURL(string shortenedURL)
        {
            return _urlShortenerRepository.GetByShortURL(shortenedURL).LongUrl;
        }

        public void SaveURL(Url urlShortener)
        {
            _urlShortenerRepository.Save(urlShortener);
        }

        public List<Url> GetAll()
        {
            return _urlShortenerRepository.GetAll();
        }
    }
}
