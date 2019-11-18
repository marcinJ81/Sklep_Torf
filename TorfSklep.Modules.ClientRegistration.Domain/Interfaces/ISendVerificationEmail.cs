using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.Interfaces
{
    public interface ISendVerificationEmail
    {
        bool SendVerificationEmail(int user_id);
    }
}
