using System;
using System.Collections.Generic;
using System.Text;

namespace TorfSklep.Modules.UserRegistration.Respository.UnidentifiedUsers
{
    public interface IUniedetifiedUsers
    {
        List<UnidentifiedUsers> GetUnidentifiedUsersList();
        void AddUnidentifiedUser(int user_id, Reason reason, DateTime dateReason);
        void DeleteUserFromUnidentifiedList(int user_id);
    }
}
