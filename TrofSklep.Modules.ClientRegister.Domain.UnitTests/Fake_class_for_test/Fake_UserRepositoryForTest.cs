using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_UserRepositoryForTest : IUsersRepository
    {
        private List<User> getListOfUsers()
        {
            List<User> listOfUsers = new List<User>();
            listOfUsers.Add(
            new User
            {
                user_id = 1,
                user_name = "active account",
                user_login = "wolnylogin",
                user_account_active = 1,
                user_email = "test@test",
                user_ban = false,
                external_id = "1234"

            });
            listOfUsers.Add(new User
            {
                user_id = 0,
                user_name = "unactive account",
                user_login = "zajety",
                user_account_active = 0,
                user_email = "test_test",
                user_ban = true,
                external_id =""
            });
            return listOfUsers;
        }
        
        public bool AddUser(User user)
        {
            if ((user.user_id == 1) && (user.user_name == "julian") && (user.user_login == "wolnylogin"))
                return true;
            else
                return false;
        }

        public bool DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }

        public User SearchUser(int user_id)
        {
            return new User()
            {
                user_id = 1,
                user_name = "test",
                user_login = "wolnylogin",
                user_account_active = 1,
                user_email = "test@test"
            };
        }
       public bool IsThereAUserRegister(string name,string sname,string email)
        {
            if(getListOfUsers().Any(x => x.user_name == name))
                return true;
            return false;
        }

        public bool IsAccountActive(int id_user)
        {
            if (getListOfUsers().Where(x => x.user_id == id_user).FirstOrDefault().user_account_active == 0)
                return false;
            return true;
        }

        public bool IsAccountHaveBan(int id_user)
        {
            if (getListOfUsers().Where(x => x.user_id == id_user).FirstOrDefault().user_ban)
                return true;
            return false;
        }

        public bool IsExternalIDSet(int id_user)
        {
            if (getListOfUsers().Where(x => x.user_id == id_user).FirstOrDefault().external_id.Length == 0)
                return false;
            return true;
        }

        public bool IsLoginNameFree(string loginName)
        {
            throw new NotImplementedException();
        }
    }
}
