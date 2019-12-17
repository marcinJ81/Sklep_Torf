using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface IUserAccountAttributes
    {
        bool AccountHaveBan(int id_user);
        bool AccountActive(int id_user);
        bool UserRegister(string name, string sname, string email);
    }
    public class UserAccountAttributes : IUserAccountAttributes
    {
        public bool AccountActive(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool AccountHaveBan(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool UserRegister(string name, string sname, string email)
        {
            throw new NotImplementedException();
        }
    }

}
