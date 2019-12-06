using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.Infrastructure.DataBaseSystem.DB_sklep
{
   public class TestDataBase_InFile : IQuerySqlite
    {
        public List<string> db_QueryWithoutParam_sqlConnectionAllInOne(Dictionary<string, string> queryString)
        {
            if (!queryString.Any())
                return null;

            SqliteConnection con = new SqliteConnection(@"DataSource=E:\SQLite_sklep\test.db");
            con.Open();

            string query = queryString.Where(x => x.Key == "Create").FirstOrDefault().Value;
            SqliteCommand com0 = new SqliteCommand(query, con);
            try
            {
                com0.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                string er = ex.Message;
            }

            Microsoft.Data.Sqlite.SqliteCommand com1 = new SqliteCommand(queryString.Where(x => x.Key == "Insert").FirstOrDefault().Value, con);
            com1.ExecuteNonQuery();

            Microsoft.Data.Sqlite.SqliteCommand com3 = new SqliteCommand(queryString.Where(x => x.Key == "Select").FirstOrDefault().Value, con);
            com3.ExecuteNonQuery();

            List<string> result = new List<string>();
            var rdr = com3.ExecuteReader();
            result.Add(rdr.GetName(0) + "|" + rdr.GetName(1) + "|" + rdr.GetName(2) + "|" + rdr.GetName(3) + "|" + rdr.GetName(4)
                        + "|" + rdr.GetName(5) + "|" + rdr.GetName(6));
            while (rdr.Read())
            {
                result.Add(rdr.GetString(0) + "," + rdr.GetString(1) + "," + rdr.GetString(2)
                    + "," + rdr.GetString(3) + "," + rdr.GetString(4)
                    + "," + rdr.GetString(5) + "," + rdr.GetString(6));
            }
            con.Close();
            return result;
        }

    }
}
