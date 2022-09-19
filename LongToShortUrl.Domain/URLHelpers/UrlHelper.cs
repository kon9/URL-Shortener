using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LongToShortUrl.Domain.URLHelpers
{
    internal static class UrlHelper
    {
        internal static bool IsUrlValid(string url)
        {
            Uri uri = new Uri(url);

            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
