using KeywordSearch.Data.Repository;
using KeywordSearch.Data.Repository.Interface;
using KeywordSearch.Model;
using KeywordSearch.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System.Xml;

namespace KeywordSearch.Services
{
    public class WebScraperService : IWebScraperService
    {

        private readonly ISearchRepository searchRepository;

        public WebScraperService(ISearchRepository searchRepository)
        {
            this.searchRepository = searchRepository;
        }

        public async Task<IEnumerable<string>> ScrapeUrlForKeyword(string url, string keyword)
        {

            var content = new HtmlContentDownloader(url,keyword).GetContent();
            var result = GetPositionsofKeyword(content);

            searchRepository.Add(new SearchRecord
            {
                DateCreated = DateTime.Now,
                NumberOfResult = result.Count(),
                Positions = String.Join(",", result)
            });

            return result;
        }

        private static IEnumerable<string> GetPositionsofKeyword(string content)
        {
            var pattern = @"<div class=""ZINbbc xpd O9g5cc uUPGi"">\s*(.+?)</div>";
            var regex = new Regex(pattern);
            var result = regex.Matches(content).ToList();
            var results = result.Where(x => x.Value.Contains("infotrack")).Select(x => (result.IndexOf(x) + 1).ToString());

            return results;
        }
    }
}
