using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface ICheckAndFindUser
    {
        bool CheckLoginAvaible_ToBase(string loginName);
       
    }

    public class CheckAndAddUser : ICheckAndFindUser
    {
        

        public bool CheckLoginAvaible_ToBase(string loginName)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_login == loginName))
                return false;
            return true;
        }
    }
}
