using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorfSklep.Modules.ExternalSystem.Repository
{
    public class ExternalID : IExternalIdFunctions
    {
        private string external_id;
        private int external_numberOfAttempts;
        private int user_id;
        private List<ExternalID> listOfOrdersAwaitingIdentifier;
        public ExternalID()
        {
            this.listOfOrdersAwaitingIdentifier = new List<ExternalID>();
        }
        public bool AddExternalIDToList(int user_id)
        {
            int attempts = GetNumberOfAttempts(user_id);
            this.listOfOrdersAwaitingIdentifier.Add(new ExternalID
            {
                external_id = String.Empty,
                external_numberOfAttempts = attempts,
                user_id = user_id
            });
            return true;

        }
        public int GetNumberOfAttempts(int user_id)
        {
            if (!listOfOrdersAwaitingIdentifier.Any(x => x.user_id == user_id))
            {
                return 0;
            }
            return listOfOrdersAwaitingIdentifier.Where(x => x.user_id == user_id).FirstOrDefault().external_numberOfAttempts;
        }

        public List<ExternalID> list_UsersWaitingForId()
        {
            return listOfOrdersAwaitingIdentifier.Where(x => String.IsNullOrEmpty(x.external_id) == true).ToList();                                   
        }

        public List<ExternalID> list_userWithEternalId()
        {
            return listOfOrdersAwaitingIdentifier.Where(x => String.IsNullOrEmpty(x.external_id) == false).ToList();
        }
    }

    
}
