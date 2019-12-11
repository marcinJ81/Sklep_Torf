using System;
using System.Collections.Generic;
using System.Text;
using TorfSklep.Infrastructure.ExternalSystemID;
using TorfSklep.Modules.ExternalSystem.Repository;
using TorfSklep.Modules.UserRegistration.Domain.Interfaces;
using TorfSklep.Modules.UserRegistration.Respository;

namespace TorfSklep.Modules.UserRegistration.Domain.Class
{
    public class ExternalSytemComunication : ALimitAttemptsExternalSystem, IExternalSytemComunication
    {
        private readonly  IExternalIdFunctions externalId;
        private readonly IUsersRepository userRepo;
        public ExternalSytemComunication(IExternalIdFunctions externalID, IUsersRepository userRepository)
        {
            this.userRepo = userRepository;
            this.externalId = externalID;
        }

        public bool AssignAnExternalIdentifier(int id_user)
        {
            if (userRepo.IsExternalIDSet(id_user) == false)
                return true;
            return false;
        }

        public bool SendOrderToExternalSystem(int user_id)
        {
            if (externalId.GetNumberOfAttempts(user_id) < LIMITOFSEND && externalId.GetNumberOfAttempts(user_id) > 0)
            {
                return externalId.AddExternalIDToList(user_id);
            }
            if (externalId.GetNumberOfAttempts(user_id) == 0)
            {
                return externalId.AddExternalIDToList(user_id);
            }
            if (externalId.GetNumberOfAttempts(user_id) >= LIMITOFSEND)
            {
                return false;
            }
            return false;
        }

    }
}
