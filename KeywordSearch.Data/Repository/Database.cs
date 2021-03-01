using KeywordSearch.Data.Repository.Interface;
using KeywordSearch.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeywordSearch.Data.Repository
{
    public class Database : IDatabase
    {
        private readonly string ConnectionString;
        public Database(DbSettings settings)
        {
            ConnectionString = settings.ConnectionString;
        }

        public void Add(SearchRecord entity)
        {
            using (SqlConnection sqlconn = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(GetInsertCommand(entity)))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                command.Connection = sqlconn;
                sqlconn.Open();
                sda.InsertCommand = command;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SearchRecord> GetList()
        {
            using (SqlConnection sqlconn = new SqlConnection(ConnectionString))
            using (SqlCommand command = new SqlCommand(GetListItems()))
            using (SqlDataAdapter sda = new SqlDataAdapter())
            {
                command.Connection = sqlconn;
                sqlconn.Open();
                sda.SelectCommand= command;
                var sdr = command.ExecuteReader();
                while(sdr.Read())
                {
                    yield return new SearchRecord
                    {
                        ID = (Guid)sdr["ID"],
                        DateCreated = (DateTime)sdr["DateCreated"],
                        NumberOfResult = (int)sdr["NumberOfResults"],
                        Positions = sdr["Positions"].ToString()
                    };
                }
            }
        }
        private string GetInsertCommand(SearchRecord entity) => $@"INSERT INTO SearchRecords
                VALUES ('{Guid.NewGuid()}','{MapDate(entity.DateCreated)}','{entity.Positions}','{entity.NumberOfResult}')";

        private string GetListItems() => $"Select * from {nameof(SearchRecord)}s";

        private string MapDate(DateTime date) =>$"{date.Year}-{date.Month}-{date.Day} {date.Hour}:{date.Minute}:{date.Second}";

    }
}
