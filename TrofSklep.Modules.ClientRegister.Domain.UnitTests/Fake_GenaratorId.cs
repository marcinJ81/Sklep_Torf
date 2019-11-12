using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;

namespace TorfSklep.Modules.UserRegistration.Domain.UnitTests
{
    public class Fake_GenaratorId : IGenerateUserId<string>
    {
        public string GenerateUserId()
        {
            return "1234";
        }
    }
}
