using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.Interfaces
{
    public interface ISendSecondVerificationEmail
    {
        bool SendVerificationEmail(int id_user,string name,string sname, string email);
    }
}
