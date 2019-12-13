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
        public InMemmoryDB()
        {
            this.testDataBase = new TestDataBase_InMemmory();
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
