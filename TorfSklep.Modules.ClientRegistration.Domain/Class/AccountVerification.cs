using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.Class
{
    public class AccountVerification : IAccountVerification
    {
        private readonly IVerificationAccount requestVerificationAccount;
        private readonly ISendEmail mailSystem;

        public AccountVerification(IVerificationAccount requestVerificationAccount, ISendEmail mailSystem)
        {
            this.requestVerificationAccount = requestVerificationAccount;
            this.mailSystem = mailSystem;
        }
        public bool VerifyTheAccount(int id_user)
        {
            if (requestVerificationAccount.UserIsInList(id_user) == true)
            {
                return Result.failure("User not in list accounts for verification ");
            }
            if (this.mailSystem.IsTheVerificationTokenValid(id_user) == false)
            {
                return Result.failure("User token is not valid");
            }
            return Result.success();
        }
    }
}
