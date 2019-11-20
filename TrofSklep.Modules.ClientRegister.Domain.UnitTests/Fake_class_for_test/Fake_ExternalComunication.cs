using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Fake_class_for_test
{
    public class Fake_ExternalComunication : IExternalIdFunctions
    {
        public bool AddExternalIDToList(int user_id)
        {
            return true;
        }

        public int GetNumberOfAttempts(int user_id)
        {
            if( user_id == 1)
                return 0;
            if (user_id == 2)
                return 1;
            if (user_id == 3)
                return 2;
            return 0;
        }

        public List<ExternalID> list_UsersWaitingForId()
        {
            throw new NotImplementedException();
        }

        public List<ExternalID> list_userWithEternalId()
        {
            throw new NotImplementedException();
        }
    }
}
