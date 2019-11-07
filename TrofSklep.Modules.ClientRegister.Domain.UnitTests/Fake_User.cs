using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_UserForTest : IUsersRepository
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
            throw new NotImplementedException();
        }
    }
}
