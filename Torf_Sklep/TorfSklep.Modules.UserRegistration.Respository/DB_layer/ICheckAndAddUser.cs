using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface ICheckAndAddUser
    {
        bool CheckLoginAvaible_ToBase(string loginName);
        bool AddUser_ToBase(User user);
    }

    public class CheckAndAddUser : ICheckAndAddUser
    {
        public bool AddUser_ToBase(User user)
        {
            throw new NotImplementedException();
        }

        public bool CheckLoginAvaible_ToBase(string loginName)
        {
            throw new NotImplementedException();
        }
    }
}
