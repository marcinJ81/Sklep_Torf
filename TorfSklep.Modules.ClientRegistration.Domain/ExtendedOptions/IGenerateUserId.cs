using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;

namespace TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions
{
    public interface IGenerateUserId<T> where T : class
    {
        T GenerateUserId();
    }

 


}
