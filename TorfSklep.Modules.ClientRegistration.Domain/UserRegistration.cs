using System;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public class UserRegistration : IUserRegistration
    {
        private readonly ICheckingAvailabilityUserLogin availabilityUserName;
        private readonly IUsersRepository usersRepository;

        public UserRegistration(IUsersRepository usersRepository, ICheckingAvailabilityUserLogin availabilityUserName)
        {
            this.usersRepository = usersRepository;
            this.availabilityUserName = availabilityUserName;
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
       
        public void WerifyTheAccount() { }
        public void AssignAnExternalIdentifier()
        {
            throw new NotImplementedException();
        }

        public bool SendVerificationEmail(int id_user)
        {
            if (!usersRepository.IsThereAUserExist(id_user))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
