using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_MailSystem : ISendEmail
    {
        public bool SendEmail(int id_user)
        {
            return true;
        }
    }
}
