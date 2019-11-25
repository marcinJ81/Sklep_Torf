using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.DataBase.BC_UserRegistration;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Module.UserRegistration.Repository.UTest
{
    public class Fake_userRepositoryInMemory : IUsersRepository
    {
        private DB_Methods dbMethods;
        private IRepoFunction<User> repofunction;
        public Fake_userRepositoryInMemory()
        {
            this.dbMethods = new DB_Methods();
            this.repofunction = new Repofunction<User>();
        }
        public bool AddUser(User user)
        {
           
            string query = @"insert into user_register values
                            (1,'test_imie','test_nazwisko','test_login','test_email',1,0,NULL)";
            string userName = dbMethods.db_QueryWithoutParam_sqlConnectionAllInOne(query);
            if (userName.Length > 0)
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
            AddUser(new User());
            var result = this.repofunction.GetAllRows();
            User user = new User();
            var source = result.First();
            user.user_id = source.user_id;
            return user;
        }
    }
}
