using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.DataBaseSystem.DB_sklep;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public class InMemmoryDB : IInFileMemmoryDB<User>
    {
        protected IQuerySqlite testDataBase;
        public string createTable { get; }
        public string selectUserTable { get; }
        public string deleteUserTable { get; }
        public InMemmoryDB(IQuerySqlite dbInMemory)
        {
            this.testDataBase = new TestDataBase_InMemmory();
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
            this.deleteUserTable = @"delete from user_register";
            this.testDataBase = dbInMemory;
        }

        public List<User> select_AllRows()
        {
            throw new NotImplementedException();
        }

        public bool insert_OneElement(User sometable)
        {
            throw new NotImplementedException();
        }

        public bool delete_OneElement(User sometable)
        {
            throw new NotImplementedException();
        }

        public User update_OneElement(User sometable)
        {
            throw new NotImplementedException();
        }
    }
}
