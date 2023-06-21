namespace LongToShortUrl.Core.Models;

public class LinkStatistic
{
    public int Id { get; set; }
    public DateTime AccessTime { get; set; }
    public string UserAgent { get; set; }
    public string UserPlatform { get; set; }
    public string UserBrowser { get; set; }
    public Url Url { get; set; }
    public int UrlId { get; set; }
}