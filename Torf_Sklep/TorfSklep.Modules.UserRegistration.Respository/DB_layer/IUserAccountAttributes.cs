using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Respository.DB_layer
{
    public interface IUserAccountAttributes 
    {
        bool AccountHaveBan(int id_user);
        bool AccountActive(int id_user);
        bool UserRegister(string name, string sname, string email);
    }
    public class UserAccountAttributes : ADBInMemory, IUserAccountAttributes
    {
        public UserAccountAttributes()
            : base() { }
        public bool AccountHaveBan(int id_user)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_ban == true))
                return false;
            return true;
        }
        public bool AccountActive(int id_user)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_account_active == 1))
                return true;
            return false;
        }
        public bool UserRegister(string name, string sname, string email)
        {
            List<User> result = GetAllUsers();
            if (result.Any(x => x.user_name == name && x.user_sname == sname && x.user_email == email))
                return true;
            return false;
        }
    }

}
