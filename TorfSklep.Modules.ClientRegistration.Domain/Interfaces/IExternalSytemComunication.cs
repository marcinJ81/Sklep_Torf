using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.Interfaces
{
    public interface IExternalSytemComunication
    {
        bool SendOrderToExternalSystem(int user_id);
    }
}
