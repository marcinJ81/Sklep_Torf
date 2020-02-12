using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public class FirstVerificationMail : ISendVerificationEmail
    {
        private readonly IVerificationAccount requestVerificationAccount;
        private readonly ISendEmail mailSystem;

        public FirstVerificationMail(IVerificationAccount requestVerificationAccount, ISendEmail mailSystem)
        {
            this.requestVerificationAccount = requestVerificationAccount;
            this.mailSystem = mailSystem;
        }
        public bool SendVerificationEmail(int user_id)
        {
            if (requestVerificationAccount.UserIsInList(user_id) == true)
            {
                mailSystem.SendEmail(user_id);
                return Result.failure("User is in list to verification email");
            }
            mailSystem.SendEmail(user_id);
            return Result.success();
        }
    }
}
