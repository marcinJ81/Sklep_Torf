using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.DataBase.BC_UserRegistration;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Module.UserRegistration.Repository.UTest
{
    public class Fake_userRepositoryInMemory : IUsersRepository
    {
        private DB_Methods dbMethods;
        public Fake_userRepositoryInMemory()
        {
            this.dbMethods = new DB_Methods();
        }
        public bool AddUser(User user)
        {
            string query = @"insert into user_register values
                            (1,'test_imie','test_nazwisko','test_login','test_email',1,0,NULL)";
            int numberOfRows = dbMethods.db_QueryWithoutParam_IDbConnection(query);
            if (numberOfRows > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountActive(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsAccountHaveBan(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsExternalIDSet(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool IsThereAUserExist(int id_user)
        {
            throw new NotImplementedException();
        }

        public User SearchUser(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
