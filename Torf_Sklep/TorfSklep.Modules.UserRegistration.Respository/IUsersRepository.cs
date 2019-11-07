using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository
{
    public interface IUsersRepository
    {
        bool AddUser(User user);
        bool DeleteUser(int user_id);
        User SearchUser(int user_id);
    }
}
