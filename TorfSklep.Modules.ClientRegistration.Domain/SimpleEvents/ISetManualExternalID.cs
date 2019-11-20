using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers;

namespace TorfSklep.Modules.UserRegistration.Domain.SimpleEvents
{
    public interface ISetManualExternalID
    {
        List<UnidentifiedUsers> AddToListManualSetExternalID(int user_id,Reason reson);
    }
}
