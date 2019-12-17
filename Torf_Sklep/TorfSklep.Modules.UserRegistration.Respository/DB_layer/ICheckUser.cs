using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface ICheckUser
    {
        bool CheckLoginAvaible_ToBase(string loginName);
    }

    public class UserChecker : ICheckUser
    {
        private readonly ISearchUser searchUser;
        public UserChecker(ISearchUser searchUser)
        {
            this.searchUser = searchUser;
        }
        public bool CheckLoginAvaible_ToBase(string loginName)
        {
            List<User> result = this.searchUser.GetAllUsers();
            if (result.Any(x => x.user_login == loginName))
                return false;
            return true;
        }
    }
}
