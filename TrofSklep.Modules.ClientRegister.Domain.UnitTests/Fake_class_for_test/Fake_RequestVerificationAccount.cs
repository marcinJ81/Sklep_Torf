using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;
using TorfSklep.Modules.UserRegistration.Respository.AcoountVerification_Repository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_RequestVerificationAccount : IVerificationAccount
    {
        private List<ListAccountToVerification> listAccount;
        public Fake_RequestVerificationAccount()
        {
            this.listAccount = new List<ListAccountToVerification>();
            this.listAccount.Add(new ListAccountToVerification
            {
                account_id = 1,
                user_id = 0,
                request_status = 1
            }
            );
        }
        public bool AddAccountToVerification(int id_user)
        {
            throw new NotImplementedException();
        }

        public bool UserIsInList(int id_user)
        {
            if (this.listAccount.Any(x => x.user_id == id_user))
                return true;
            return false;
        }
    }
}
