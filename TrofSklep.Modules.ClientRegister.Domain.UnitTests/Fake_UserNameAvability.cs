using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.Tests
{
    public class Fake_UserLoginAvability : ICheckingAvailabilityUserLogin
    {
        public bool WhetherUserLoginIsAvailable(string userName)
        {
            if (userName == "wolnylogin")
                return true;
            else
                return false;
        }
    }
}
