using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions
{
    public class GeneratorId : IGenerateUserId<string>
    {
        public string GenerateUserId()
        {
            throw new NotImplementedException();
        }
    }
}
