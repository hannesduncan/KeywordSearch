using KeywordSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Data.Repository.Interface
{
    public interface IDatabase
    {
        public IEnumerable<SearchRecord> GetList();
        public void Add(SearchRecord entity); 

    }
}
