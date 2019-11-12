using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace Torf_Sklep.Infrastructure.EmailSystem
{
    public interface ISendEmail
    {
        bool SendEmail(int id_user);
    }
}
