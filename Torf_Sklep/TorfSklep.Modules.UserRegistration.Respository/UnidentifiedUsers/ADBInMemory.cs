using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public abstract class ADBInMemory
    {
        protected IQuerySqlite testDataBase;
        public string createTable { get; }
        public string selectUserTable { get; }
        public ADBInMemory()
        {
            this.createTable = @"CREATE TABLE IF NOT EXISTS user_register
                (
                    user_id INTEGER IDENTITY PRIMARY KEY,
                    user_name VARCHAR NOT NULL,
                    user_sname VARCHAR NOT NULL,
                    user_login VARCHAR UNIQUE,
                    user_email VARCHAR NOT NULL,
                    user_account_active INT NOT NULL,
                    user_ban BIT NOT NULL,
                    external_id VARCHAR NOT NULL
                );";
            this.selectUserTable = @"select user_id, user_name,user_sname," +
                                   "user_login,user_email, user_account_active " +
                                   " user_ban, external_id from user_register";
        }
        protected string getInsertQuery(User user)
        {
            string insertQuery = @"insert into user_register values"
                                + "(" + user.user_id.ToString() + ",'" + user.user_name + "','" + user.user_sname + "','"
                                + user.user_login + "','" + user.user_email + "'," + user.user_account_active.ToString()
                                + "," + user.user_ban + "," + "'" + user.external_id + "'" + ")";
            return insertQuery;
        }
        protected string getInsertMany(List<User> listUser)
        {
            if (!listUser.Any())
            {
                return String.Empty;
            }
            string result = String.Empty;
            foreach (var i in listUser)
            {
                result += getInsertQuery(i) + " ; ";
            }
            return result;
        }

        
        
       
       
       
    }
}
