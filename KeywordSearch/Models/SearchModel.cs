using KeywordSearch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeywordSearch.Models
{
    public class SearchModel
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string Keyword { get; set; }

        public IEnumerable<string> Results { get; set; }

        public IEnumerable<SearchRecord> SearchRecords { get; set; }

    }
}
