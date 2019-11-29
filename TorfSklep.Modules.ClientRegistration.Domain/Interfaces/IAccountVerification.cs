using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.Interfaces
{
   public interface IAccountVerification
    {
         bool VerifyTheAccount(int id_user);
    }
}
