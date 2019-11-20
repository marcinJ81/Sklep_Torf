using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;

namespace TorfSklep.Modules.UserRegistration.Domain.Class
{
    public class ExternalSytemComunication : IExternalSytemComunication
    {
        public bool SendOrderToExternalSystem(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
