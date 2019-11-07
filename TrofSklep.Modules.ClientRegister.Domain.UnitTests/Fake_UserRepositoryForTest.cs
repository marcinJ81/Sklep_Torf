using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_UserRepositoryForTest : IUsersRepository
    {
        public bool AddUser(User user)
        {
            if ((user.user_id == 1) && (user.user_name == "test") && (user.user_login == "wolnylogin"))
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
            return new User() { user_id = 1, user_name = "test", user_login = "wolnylogin" };
        }
       public bool IsThereAUserExist(int id_user)
        {
            if (id_user == 1)
                return true;
            return false;
        }


    }
}
