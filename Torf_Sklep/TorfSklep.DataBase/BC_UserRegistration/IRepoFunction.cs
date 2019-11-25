using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorfSklep.DataBase.BC_UserRegistration
{
    public interface IRepoFunction<T>
    {
        List<T> GetAllRows();
    }
    public interface IRepoFunctionReturnJSON
    {
        string GeAllRows();
    }

    public class Repofunction<T> : IRepoFunction<T> where T : class, new()
    {
        private readonly DB_UserRegistration dbUser;
        private DB_Methods dbMethods;
        public Repofunction()
        {
            this.dbUser = new DB_UserRegistration();
            dbMethods = new DB_Methods();
        }
        public List<T> GetAllRows()
        {
            List<T> result = new List<T>();
            string sqlText = @"select * from user_register";
            var con = new System.Data.SQLite.SQLiteConnection(this.dbUser.getconstring);
            con.Open();

            var cmd = new SQLiteCommand(sqlText, con);
            cmd.CommandText = sqlText;
            SQLiteDataReader rdr = cmd.ExecuteReader();

            //while (rdr.Read())
            //{
            //    result.Add(new dynamic { rdr.GetInt32(0) });
            //}
            //cmd.Parameters.AddWithValue("@name", "BMW");
            //cmd.Parameters.AddWithValue("@price", 36600);
            return null;

        }
    }
}
