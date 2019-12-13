using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public class InfileDB : IInFile<User>
    {
        protected IQuerySqlite testDataBase;

        public bool create_table()
        {
            throw new NotImplementedException();
        }

        public bool delete_OneElement(User sometable)
        {
            throw new NotImplementedException();
        }

        public bool drop_table()
        {
            throw new NotImplementedException();
        }

        public bool insert_OneElement(User sometable)
        {
            throw new NotImplementedException();
        }

        public bool insert_testData()
        {
            throw new NotImplementedException();
        }

        public List<User> select_AllRows()
        {
            throw new NotImplementedException();
        }

        public User update_OneElement(User sometable)
        {
            throw new NotImplementedException();
        }
    }
}
