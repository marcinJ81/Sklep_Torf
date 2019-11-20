using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.ExternalSystemID;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;

namespace TorfSklep.Modules.UserRegistration.Domain.Class
{
    public class ExternalSytemComunication : ALimitAttemptsExternalSystem, IExternalSytemComunication
    {
        private readonly  IExternalIdFunctions externalId;
        public ExternalSytemComunication(IExternalIdFunctions externalID)
        {
            this.externalId = externalID;
        }
        public bool SendOrderToExternalSystem(int user_id)
        {
            if (externalId.GetNumberOfAttempts(user_id) < LIMITOFSEND && externalId.GetNumberOfAttempts(user_id) > 0)
            {
                return externalId.AddExternalIDToList(user_id);
            }
            if (externalId.GetNumberOfAttempts(user_id) == 0)
            {
                return externalId.AddExternalIDToList(user_id);
            }
            if (externalId.GetNumberOfAttempts(user_id) >= LIMITOFSEND)
            {
                return false;
            }
            return false;
        }
    }
}
