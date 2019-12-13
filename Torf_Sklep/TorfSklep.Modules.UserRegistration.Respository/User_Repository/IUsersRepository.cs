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
        bool IsThereAUserRegister(string name,string sname,string email);
        bool IsAccountActive(int id_user);
        bool IsAccountHaveBan(int id_user);
        bool IsExternalIDSet(int id_user);
        bool IsLoginNameFree(string loginName);
    }

    public interface IuserRepository_insert
    {
        List<User> insertUsers(List<User> listUsers);
    }
}
