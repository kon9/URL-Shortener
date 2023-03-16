using LongToShortUrl.Domain.Models;

namespace LongToShortUrl.Data.Repo
{
    public interface IURLShortenerRepository
    {
        bool Exists(string url);
        void Save(Url url);
        Url GetByLongURL(string longURL);
        Url GetByShortURL(string shortenedURL);
        List<Url> GetAll();

    }
}
