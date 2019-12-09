using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions
{
    public class UserNameAvability : ICheckingAvailabilityUserLogin
    {
        private readonly IUsersRepository userRepo;
        public UserNameAvability(IUsersRepository userRepo)
        {
            this.userRepo = userRepo;
        }
        public bool WhetherLoginNameIsAvailable(string userLogin)
        {
            if (userRepo.IsLoginNameFree(userLogin))
                return true;
            return false;
        }
    }
}
