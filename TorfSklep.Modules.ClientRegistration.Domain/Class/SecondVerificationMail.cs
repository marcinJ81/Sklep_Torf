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
        public bool SendVerificationEmail(int id_user,string name,string sname, string email)
        {
            if (usersRepository.IsThereAUserRegister(name,sname,email) == false)
            {
                return Result.failure("User not register");
            }
            if (requestVerificationAccount.UserIsInList(id_user) == true)
            {
                return Result.failure("User is not in list verifiacation email");
            }
           
            if (usersRepository.IsAccountActive(id_user) == false)
            {
                return Result.failure("Acsount is not active");
            }
            if (usersRepository.IsAccountHaveBan(id_user) == true)
            {
                return Result.failure("Account have ban");
            }
            return mailSystem.SendEmail(id_user);
        }
    }
}
