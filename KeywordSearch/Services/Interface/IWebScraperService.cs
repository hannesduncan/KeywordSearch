using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeywordSearch.Services.Interface
{
    public interface IWebScraperService
    {
        Task<IEnumerable<string>> ScrapeUrlForKeyword(string url, string keyword);
    }
}
