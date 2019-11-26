using System;
using System.Collections.Generic;
using System.Text;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.Class
{
    public class SecondVerificationMail :ISendSecondVerificationEmail
    {
        private readonly IVerificationAccount requestVerificationAccount;
        private readonly IUsersRepository usersRepository;
        private readonly ISendEmail mailSystem;
        public SecondVerificationMail(IVerificationAccount requestVerificationAccount, IUsersRepository usersRepository,
             ISendEmail mailSystem)
        {
            this.usersRepository = usersRepository;
            this.requestVerificationAccount = requestVerificationAccount;
            this.mailSystem = mailSystem;
        }
        public bool SendVerificationEmail(int id_user)
        {
            if (requestVerificationAccount.UserIsInList(id_user) == true)
            {
                return false;
            }
            if (usersRepository.IsThereAUserExist(id_user) == false)
            {
                return false;
            }
            if (usersRepository.IsAccountActive(id_user) == false)
            {
                return false;
            }
            if (usersRepository.IsAccountHaveBan(id_user) == true)
            {
                return false;
            }
            return mailSystem.SendEmail(id_user);
        }
    }
}
