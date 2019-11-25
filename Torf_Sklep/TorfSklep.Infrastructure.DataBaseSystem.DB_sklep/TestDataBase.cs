using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.Infrastructure.DataBaseSystem.DB_sklep
{
    public class TestDataBase : IQuerySqlite
    {
      
        public List<string> db_QueryWithoutParam_sqlConnectionAllInOne(string sqlCreateTable, string sqlInsert, string sqlSelect,int columnAmount)
        {
            SqliteConnection con = new SqliteConnection(@"DataSource=:memory:");
            con.Open();

            string query = sqlCreateTable;
            SqliteCommand com0 = new SqliteCommand(query, con);
            com0.ExecuteNonQuery();

            Microsoft.Data.Sqlite.SqliteCommand com1 = new SqliteCommand(sqlInsert, con);
            com1.ExecuteNonQuery();

            Microsoft.Data.Sqlite.SqliteCommand com3 = new SqliteCommand(sqlSelect, con);
            com3.ExecuteNonQuery();

            List<string> result = new List<string>();
           var rdr = com3.ExecuteReader();
            result.Add(rdr.GetName(0) + " " + rdr.GetName(1) + " " + rdr.GetName(2));
            while (rdr.Read())
            {
                result.Add(rdr.GetString(0) + " " + rdr.GetString(1) + " " + rdr.GetString(2));
            }
            con.Close();
            return result;

        }
    }
}
