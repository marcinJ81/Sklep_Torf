using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;

namespace TorfSklep.Modules.UserRegistration.Domain.SimpleEvents
{
    public class SuccesEmail : ISendSuccesEmail
    {
        private ISendEmail sendEmail;
        public SuccesEmail(ISendEmail mailSystem)
        {
            this.sendEmail = mailSystem;
        }
        public void SendSuccesEmail(int user_id)
        {
            sendEmail.SendEmail(user_id);
        }
    }
}
