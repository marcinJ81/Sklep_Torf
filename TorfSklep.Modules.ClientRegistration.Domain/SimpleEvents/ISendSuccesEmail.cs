using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.SimpleEvents
{
   public interface ISendSuccesEmail
    {
        void SendSuccesEmail(int user_id);
    }
}
