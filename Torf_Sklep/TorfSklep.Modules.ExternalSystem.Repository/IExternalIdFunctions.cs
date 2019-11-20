using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.ExternalSystem.Repository
{
    public interface IExternalIdFunctions
    {
         bool AddExternalIDToList(int user_id);
         int GetNumberOfAttempts(int user_id);
        List<ExternalID> list_userWithEternalId();
        List<ExternalID> list_UsersWaitingForId();
    }
}
