using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Domain.SimpleEvents
{
    public class ManualVerification : ISetManualExternalID
    {
        private IUniedetifiedUsers uniedetifiedUser;
    }
}
