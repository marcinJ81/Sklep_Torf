﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public interface IVerificationEmail
    {
        bool SendEmailSuccesVerification(int id_user);
        void InformTheCustomerAboutTheExtendedRegistrationTime(int user_id);
    }
}
