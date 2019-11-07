using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions
{
    public class UserNameAvability : ICheckingAvailabilityUserLogin
    {
        public bool WhetherUserLoginIsAvailable(string userLogin)
        {
            throw new NotImplementedException();
        }
    }
}
