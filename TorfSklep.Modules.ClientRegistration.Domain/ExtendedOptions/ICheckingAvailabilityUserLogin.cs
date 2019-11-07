using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public interface ICheckingAvailabilityUserLogin
    {
        bool WhetherUserLoginIsAvailable(string userLogin);
    }
}
