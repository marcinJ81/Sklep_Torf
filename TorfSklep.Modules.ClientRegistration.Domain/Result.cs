using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public static class Result
    {
        public static bool success()
        {
            return true;
        }

        public static bool failure(string reason)
        {
            return false;
        }
    }
}
