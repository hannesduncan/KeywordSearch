using KeywordSearch.Data.Repository.Interface;
using KeywordSearch.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Data.Repository
{
    public class SearchRepository : ISearchRepository
    {
        private readonly IDatabase Database;
        public SearchRepository(IDatabase db)
        {
            Database = db;
        }

        public void Add(SearchRecord record)
        {
            Database.Add(record);
        }

        public IEnumerable<SearchRecord> GetSearchHistory()
        {
            return Database.GetList()
                .OrderByDescending(x => x.DateCreated)
                .Skip(1);
        }
    }
}
