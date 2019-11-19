using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.ExternalSystem.Repository
{
    public interface IAddARequestToAssignAnExternalIDToQueue
    {
        bool AddToQueue(int user_id);
        int GetFirstElementOfTheQueue();
    }
}
