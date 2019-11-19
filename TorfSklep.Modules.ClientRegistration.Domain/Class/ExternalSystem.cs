using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;

namespace TorfSklep.Modules.UserRegistration.Domain.Class
{
    public class ExternalSytemComunication : IExternalSytemComunication
    {
        private const int LIMITOFSEND = 2; 
        private IExternalIdFunctions exteranlId;
        public ExternalSytemComunication(IExternalIdFunctions externalIdFunctions)
        {
            this.exteranlId = externalIdFunctions;
        }
        public bool SendOrderToExternalSystem(int user_id)
        {
            if (exteranlId.GetNumberOfAttempts(user_id) == LIMITOFSEND)
            {
                return false;
            }
            if (exteranlId.GetNumberOfAttempts(user_id) == 0)
            {
                return true;
            }
            if (exteranlId.GetNumberOfAttempts(user_id) < 2)
            {
                return true;
            }
            return false;
        }
    }
}
