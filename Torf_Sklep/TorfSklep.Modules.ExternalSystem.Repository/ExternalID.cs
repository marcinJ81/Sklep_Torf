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

        public ExternalID()
        {
            this.list_userWithEternalId = new List<ExternalID>();
        }

        public List<ExternalID> list_userWithEternalId { get; }

        public void AddExternalIDToList(string external_id, int number_Attempts, int user_id)
        {
            this.list_userWithEternalId.Add(new ExternalID
            {
                external_id = external_id,
                external_numberOfAttempts = number_Attempts,
                user_id = user_id
            });
        }

        public int GetNumberOfAttempts(int user_id)
        {
            if (!list_userWithEternalId.Any(x => x.user_id == user_id))
            {
                return 0;
            }
            return list_userWithEternalId.Where(x => x.user_id == user_id).FirstOrDefault().external_numberOfAttempts;
        }
    }

    
}
