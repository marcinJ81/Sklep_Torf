using System;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public class UserRegistration : IUserRegistration
    {
        private readonly ICheckingAvailabilityUserLogin availabilityUserName;
        private readonly IUsersRepository usersRepository;
        private readonly IVerificationAccount requestVerificationAccount;
        private readonly ISendEmail mailSystem;

        public UserRegistration(IUsersRepository usersRepository, 
                                ICheckingAvailabilityUserLogin availabilityUserName)
        {
            this.usersRepository = usersRepository;
            this.availabilityUserName = availabilityUserName;
        }
        public UserRegistration(IUsersRepository usersRepository,
                                ICheckingAvailabilityUserLogin availabilityUserName,
                                IVerificationAccount requestVerificationAccount,
                                ISendEmail mailSystem)
        : this(usersRepository,availabilityUserName)
        {
            this.usersRepository = usersRepository;
            this.availabilityUserName = availabilityUserName;
            this.requestVerificationAccount = requestVerificationAccount;
            this.mailSystem = mailSystem;
        }


        //methods
        #region Methods
        public bool RegisterUser(User user)
        {
            bool result = availabilityUserName.WhetherUserLoginIsAvailable(user.user_login);
            if (result)
            {
                return usersRepository.AddUser(user);
            }
            return result;
        }
       
        public bool VerifyTheAccount(int id_user)
        {
            if (requestVerificationAccount.UserIsInList(id_user) == true)
            {
                return false;
            }
            if (this.mailSystem.IsTheVerificationTokenValid(id_user) == false)
            {
                return false;
            }
            return true;
        }
        public bool AssignAnExternalIdentifier(int id_user)
        {
            if (usersRepository.IsExternalIDSet(id_user) == false)
                return true;
            return false;
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
        #endregion
    }
}
