using System;
using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace TorfSklep.DataBase.BC_UserRegistration
{
    //some the code comes from DNA examples
    public class DB_UserRegistration : IDBConnectionFactory
    {
        private const string CONSTRING = "DataSource=:memory:";
        private readonly SqliteConnection connection;
        public string getconstring { get; }
        public DB_UserRegistration()
        {
            connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            CreateUser();
            this.getconstring = CONSTRING;
        }
        public IDbConnection GetOpenConnection()
        {
            return connection;
        }
        private void CreateUser()
        {
            try
            {
                connection.Execute(
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
            ");
            }
            catch (DbException ex)
            {
                Console.WriteLine("GetType: {0}", ex.GetType());
                Console.WriteLine("Source: {0}", ex.Source);
                Console.WriteLine("ErrorCode: {0}", ex.ErrorCode);
                Console.WriteLine("Message: {0}", ex.Message);
            }
        }
    }
}
