using KeywordSearch.Data.Repository.Interface;
using KeywordSearch.Models;
using KeywordSearch.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KeywordSearch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebScraperService webScraper;
        private readonly ISearchRepository searchRepository;
        public HomeController(ILogger<HomeController> logger, IWebScraperService webScraper, ISearchRepository searchRepository)
        {
            _logger = logger;
            this.webScraper = webScraper;
            this.searchRepository = searchRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new SearchModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(SearchModel model)
        {
            if (ModelState.IsValid)
            {
                model.Results = await webScraper.ScrapeUrlForKeyword(model.Url, model.Keyword);
                model.SearchRecords = searchRepository.GetSearchHistory();
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
