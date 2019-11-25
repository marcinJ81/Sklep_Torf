using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace TorfSklep.DataBase.BC_UserRegistration
{
    public class DB_Methods
    {
        private readonly DB_UserRegistration dbUser;

        public DB_Methods()
        {
            this.dbUser = new DB_UserRegistration();
        }
        public int db_QueryWithoutParam_IDbConnection(string sqlText)
        {
            System.Threading.CancellationToken cancelToken = default(System.Threading.CancellationToken);
            IDbConnection connect = this.dbUser.GetOpenConnection();
            CommandDefinition command = new CommandDefinition(sqlText,null,null,null,CommandType.Text,CommandFlags.None,cancelToken);
            connect.Open();
            return connect.Execute(command);
        }
        public int db_QueryWithoutParam_sqlConnection(string sqlText)
        {
            using (SqlConnection connection = new SqlConnection(
               this.dbUser.getconstring))
            {
                SqlCommand command = new SqlCommand(sqlText, connection);
                command.Connection.Open();
               return command.ExecuteNonQuery();
            }
        }
        public int db_QueryWithoutParam_sqLiteConnection(string sqlText)
        {
            var con = new System.Data.SQLite.SQLiteConnection(this.dbUser.getconstring);
            con.Open();

            var cmd = new SQLiteCommand(sqlText,con);
            cmd.CommandText = sqlText;
            SQLiteDataReader rdr = cmd.ExecuteReader();

            //cmd.Parameters.AddWithValue("@name", "BMW");
            //cmd.Parameters.AddWithValue("@price", 36600);
            return 1;
        }

        public string db_QueryWithoutParam_sqlConnectionAllInOne(string sqlTest)
        {
            string cs = this.dbUser.getconstring;
            var con = new Microsoft.Data.Sqlite.SqliteConnection(this.dbUser.getconstring);

            con.Open();

            string query = 
                @"CREATE TABLE IF NOT EXISTS user_register
            (
                user_id INTEGER IDENTITY PRIMARY KEY,
                user_name VARCHAR NOT NULL,
                user_sname VARCHAR NOT NULL,
                user_login VARCHAR UNIQUE,
                user_email VARCHAR NOT NULL,
                user_account_active INT NOT NULL,
                user_ban BIT NOT NULL,
                external_id VARCHAR
            );
            ";

            SqliteCommand com0 = new SqliteCommand(query, con);
            com0.ExecuteNonQuery();

            Microsoft.Data.Sqlite.SqliteCommand com1 = new SqliteCommand(sqlTest, con);
            com1.ExecuteNonQuery();

            string count_table = " SELECT user_name FROM user_register";

            Microsoft.Data.Sqlite.SqliteCommand com3 = new SqliteCommand(count_table, con);
            com3.ExecuteNonQuery();

            string result = com3.ExecuteScalar().ToString();
            con.Close();

            return result;


        }
    }
}
