using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public interface IUserRegistration
    {
        bool RegisterUser(User user);
        bool VerifyTheAccount(int id_user);
        bool AssignAnExternalIdentifier(int id_user);
    }

}
