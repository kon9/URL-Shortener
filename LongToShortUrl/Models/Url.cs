namespace LongToShortUrl.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string UrlCode { get; set; }
        public string LongUrl  { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
