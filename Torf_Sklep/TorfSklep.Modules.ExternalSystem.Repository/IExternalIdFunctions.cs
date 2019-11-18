using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.ExternalSystem.Repository
{
    public interface IExternalIdFunctions
    {
         void AddExternalIDToList(string external_id, int number_Attempts, int user_id);
         int GetNumberOfAttempts(int user_id);
        List<ExternalID> list_userWithEternalId { get; }
    }
}
