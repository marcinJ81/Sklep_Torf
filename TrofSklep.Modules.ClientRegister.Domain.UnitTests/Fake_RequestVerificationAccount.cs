using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_RequestVerificationAccount : IVerificationAccount
    {
        public bool UserIsInList(int id_user)
        {
            throw new NotImplementedException();
        }
    }
}
