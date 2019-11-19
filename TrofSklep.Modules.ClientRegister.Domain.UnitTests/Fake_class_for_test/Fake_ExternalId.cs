using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.ExternalSystem.Repository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests.Fake_class_for_test
{
    public class Fake_ExternalId : IExternalIdFunctions
    {
        private string external_id;
        private int external_numberOfAttempts;
        private int user_id;
        private List<Fake_ExternalId> listResult = new List<Fake_ExternalId>();
        public Fake_ExternalId()
        {
            //AddExternalIDToList(1, 1);
        }
        public void AddExternalIDToList(int number_Attempts, int user_id)
        {
            
            this.listResult.Add(new Fake_ExternalId
            {
                external_id = String.Empty,
                external_numberOfAttempts = 0,
                user_id = 5
            });
            this.listResult.Add(new Fake_ExternalId
            {
                external_id = String.Empty,
                external_numberOfAttempts = 1,
                user_id = 2
            });
            this.listResult.Add(new Fake_ExternalId
            {
                external_id = String.Empty,
                external_numberOfAttempts = 2,
                user_id = 3
            });
        }

        public int GetNumberOfAttempts(int user_id)
        {
            if (!this.listResult.Any(x => x.user_id == user_id))
            {
                return 0;
            }
            return this.listResult.Where(x => x.user_id == user_id).FirstOrDefault().external_numberOfAttempts;
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
