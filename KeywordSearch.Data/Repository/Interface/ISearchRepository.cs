using KeywordSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Data.Repository.Interface
{
    public interface ISearchRepository
    {
        public void Add(SearchRecord record);

        public IEnumerable<SearchRecord> GetSearchHistory();
    }
}
