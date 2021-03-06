﻿using System;
using Torf_Sklep.Infrastructure.EmailSystem;
using TorfSklep.Modules.UserRegistration.Domain.ExtendedOptions;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain
{
    public class UserRegistration : IUserRegistration
    {
        private readonly ICheckingAvailabilityUserLogin availabilityUserName;
        private readonly IUsersRepository usersRepository;

        public UserRegistration(IUsersRepository usersRepository, 
                                ICheckingAvailabilityUserLogin availabilityUserName)
        {
            this.usersRepository = usersRepository;
            this.availabilityUserName = availabilityUserName;
        }

        //methods
        #region Methods
        public bool RegisterUser(User user)
        {
            bool result = availabilityUserName.WhetherLoginNameIsAvailable(user.user_login);
            if (result)
            {
                if (!String.IsNullOrEmpty(user.user_email))
                    return usersRepository.AddUser(user);
                else
                    return Result.failure("User email is null or empty");
            }
            return result;
        }
       
        
        #endregion
    }
}
