using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
   public class UnidentifiedUsers : IUniedetifiedUsers
    {
        public int user_id { get; }
        public int undentified_reason { get; }
        public DateTime undentified_date { get; }

        public UnidentifiedUsers(int user_id, Reason reason, DateTime dateOfOccurrence)
        {
            this.user_id = user_id;
            this.undentified_reason = (int)reason;
            this.undentified_date = dateOfOccurrence;
        }

        public List<UnidentifiedUsers> GetUnidentifiedUsersList()
        {
            throw new NotImplementedException();
        }

        public void AddUnidentifiedUser(int user_id, Reason reason, DateTime dateReason)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserFromUnidentifiedList(int user_id)
        {
            throw new NotImplementedException();
        }

    }
}
