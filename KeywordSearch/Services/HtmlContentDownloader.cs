using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace KeywordSearch.Services
{
    public class HtmlContentDownloader
    {
        public string Url { get; set; }

        public HtmlContentDownloader(string url,string keywords)
        {
            Url = GetSearchUrl(url,keywords);
        }

        public string GetContent()
        {
            using (var client = new WebClient())
                return client.DownloadString(Url);
        }

        private string GetSearchUrl(string url,string keywords)
        {
            var searchTerm = keywords.Replace(" ", "+");
            if (!url.StartsWith("https://"))
                url = "https://" + url;
            
            return $"{url}/search?num=100&q={searchTerm}";
        }
    }
}
