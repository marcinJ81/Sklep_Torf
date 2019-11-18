using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;

namespace TorfSklep.Modules.UserRegistration.Domain.SimpleEvents
{
    public class SuccesEmail : IVerificationEmail
    {
        private ISendEmail sendEmail;
        public SuccesEmail(ISendEmail mailSystem)
        {
            this.sendEmail = mailSystem;
        }

        public void InformTheCustomerAboutTheExtendedRegistrationTime(int user_id)
        {
            throw new NotImplementedException();
        }

        public bool SendEmailSuccesVerification(int user_id)
        {
            return sendEmail.SendEmail(user_id);
        }

    }
}
