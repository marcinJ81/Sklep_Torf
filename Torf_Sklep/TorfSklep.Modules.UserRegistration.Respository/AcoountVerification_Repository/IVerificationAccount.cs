using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository
{
    public interface IVerificationAccount
    {
        bool UserIsInList(int id_user);
    }
}
