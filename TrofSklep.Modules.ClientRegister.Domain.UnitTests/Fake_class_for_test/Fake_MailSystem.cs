using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_MailSystem : ISendEmail
    {
        public bool IsTheVerificationTokenValid(int user_id)
        {
            if (user_id == 1)
                return true;
            return false;
        }

        public bool SendEmail(int id_user)
        {
            return true;
        }

    }
}
